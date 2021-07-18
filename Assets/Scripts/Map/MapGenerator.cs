using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum gridSpace { empty, wall, ground, vertical, horizontal, corner };
    public gridSpace[,] grid;
    private int roomHeight, roomWidth;
    private Vector2 roomSizeWorldUnits;
    private float worldUnitsInOneGridCell = 1;

    List<walker> walkers;

    [SerializeField]
    [Range(0f,1f)]
    private float chanceWalkerChangeDir;
    [SerializeField]
    [Range(0f,1f)]
    private float chanceWalkerSpawn;
    [SerializeField]
    [Range(0f,1f)]
    private float chanceWalkerDestoy;
    [SerializeField]
    [Range(0f,1f)]
    private int maxWalkers;
    [SerializeField]
    [Range(0f,1f)]
    private float percentToFill;

    public GameObject ground, vertical, horizontal, corner;

    struct walker
    {
        public Vector2 dir;
        public Vector2 pos;
    }

    public void Start()
    {
        RestartLVL();
    }

    public void RestartLVL()
    {

        Setup();
        CreateGrounds();
        CreateWalls();
        SpawnMap();

    }
    void Setup()
    {
        float hw = 40;

        roomSizeWorldUnits = new Vector2(hw, hw);

        roomHeight = Mathf.RoundToInt(roomSizeWorldUnits.x / worldUnitsInOneGridCell);
        roomWidth = Mathf.RoundToInt(roomSizeWorldUnits.y / worldUnitsInOneGridCell);

        grid = new gridSpace[roomWidth, roomHeight];

        for (int x = 0; x < roomWidth - 1; x++)
        {
            for (int y = 0; y < roomHeight - 1; y++)
            {
                grid[x, y] = gridSpace.empty;
            }
        }

        walkers = new List<walker>();
        walker newWalker = new walker();
        newWalker.dir = RandomDirection();
        Vector2 spawnPos = new Vector2(Mathf.RoundToInt(roomWidth / 2.0f), Mathf.RoundToInt(roomHeight / 2.0f));
        newWalker.pos = spawnPos;

        walkers.Add(newWalker);
    }
    void CreateGrounds()
    {
        int iterations = 0;//цикл не будет работать вечно
        do
        {
            foreach (walker myWalker in walkers)
            {
                grid[(int)myWalker.pos.x, (int)myWalker.pos.y] = gridSpace.ground;
            }
            int numberChecks = walkers.Count; //может изменить счетчик в этом цикле
            for (int i = 0; i < numberChecks; i++)
            {
                if (Random.value < chanceWalkerDestoy && walkers.Count > 1)
                {
                    walkers.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < walkers.Count; i++)
            {
                if (Random.value < chanceWalkerChangeDir)
                {
                    walker thisWalker = walkers[i];
                    thisWalker.dir = RandomDirection();
                    walkers[i] = thisWalker;
                }
            }
            numberChecks = walkers.Count;
            for (int i = 0; i < numberChecks; i++)
            {
                if (Random.value < chanceWalkerSpawn && walkers.Count < maxWalkers)
                {
                    walker newWalker = new walker();
                    newWalker.dir = RandomDirection();
                    newWalker.pos = new Vector2(Random.Range(0, roomWidth), Random.Range(0, roomHeight));
                    walkers.Add(newWalker);
                }
            }
            for (int i = 0; i < walkers.Count; i++)
            {
                walker thisWalker = walkers[i];
                thisWalker.pos += thisWalker.dir;
                walkers[i] = thisWalker;
            }
            //избегать границы сетки
            for (int i = 0; i < walkers.Count; i++)
            {
                walker thisWalker = walkers[i];
                //clamp x, y, чтобы оставить границу 1 пробела: оставьте место для стен
                thisWalker.pos.x = Mathf.Clamp(thisWalker.pos.x, 1, roomWidth - 1);
                thisWalker.pos.y = Mathf.Clamp(thisWalker.pos.y, 1, roomHeight - 1);
                walkers[i] = thisWalker;
            }
            //проверьте, чтобы выйти из цикла
            if ((float)NumberOfGrounds() / (float)grid.Length > percentToFill)
            {
                break;
            }
            iterations++;
        } while (iterations < 100000);

    }
    void CreateWalls()
    {
        //левая стенка
        for (int x = 0, y = 0; y < roomWidth; y++)
        {
            grid[x, y] = gridSpace.empty;
        }
        for (int x = 1, y = 0; y < roomWidth; y++)
        {
            grid[x, y] = gridSpace.empty;
        }
        //нижнее
        for (int x = 0, y = 0; x < roomWidth; x++)
        {
            grid[x, y] = gridSpace.empty;
        }
        for (int x = 0, y = 1; x < roomWidth; x++)
        {
            grid[x, y] = gridSpace.empty;
        }
        //верх
        for (int x = 0, y = roomHeight - 1; x < roomWidth; x++)
        {
            grid[x, y] = gridSpace.empty;
        }
        for (int x = 0, y = roomHeight - 2; x < roomWidth; x++)
        {
            grid[x, y] = gridSpace.empty;
        }
        //низ
        for (int x = roomWidth - 1, y = 0; y < roomHeight; y++)
        {
            grid[x, y] = gridSpace.empty;
        }
        for (int x = roomWidth - 2, y = 0; y < roomHeight; y++)
        {
            grid[x, y] = gridSpace.empty;
        }

        for (int x = 1; x < roomWidth - 1; x++)
        {
            for (int y = 1; y < roomHeight - 1; y++)
            {
                //Если есть пол, проверьте пространство вокруг него
                if (grid[x, y] == gridSpace.empty)
                {
                    grid[x, y] = gridSpace.wall;
                }
            }

        }

        for (int x = 1; x < roomWidth - 1; x++)
        {
            for (int y = 1; y < roomHeight - 1; y++)
            {
                if (grid[x, y] == gridSpace.wall)
                {
                    int horizontalTouches = 0;
                    int verticalTouches = 0;

                    if (IsWallNear(x - 1, y))
                    {
                        horizontalTouches++;
                    }
                    if (IsWallNear(x + 1, y))
                    {
                        horizontalTouches++;
                    }
                    if (IsWallNear(x, y - 1))
                    {
                        verticalTouches++;
                    }
                    if (IsWallNear(x, y + 1))
                    {
                        verticalTouches++;
                    }

                    if (horizontalTouches >= 1 && verticalTouches == 0)
                    {
                        grid[x, y] = gridSpace.horizontal;
                    }
                    else if (horizontalTouches == 0 && verticalTouches >= 1)
                    {
                        grid[x, y] = gridSpace.vertical;
                    }
                    else
                    {
                        grid[x, y] = gridSpace.corner;
                    }
                }
            }
        }
    }

    private bool IsWallNear(int x, int y)
    {
        if (grid[x, y] != gridSpace.ground && grid[x, y] != gridSpace.empty)
            return true;
        return false;
    }

    void SpawnMap()
    {
        for (int x = 0; x < roomWidth; x++)
        {
            for (int y = 0; y < roomHeight; y++)
            {
                switch (grid[x, y])
                {
                    case gridSpace.empty:
                        break;

                    case gridSpace.ground:
                        Spawn(x, y, ground);
                        break;

                    case gridSpace.vertical:
                        Spawn(x, y, vertical);
                        break;

                    case gridSpace.horizontal:
                        Spawn(x, y, horizontal);
                        break;

                    case gridSpace.corner:
                        Spawn(x, y, corner);
                        break;
                }
            }
        }
    }
    private void Spawn(float x, float y, GameObject toSpawn)
    {
        Vector2 spawnPos = new Vector2(x, y) * worldUnitsInOneGridCell;
        //spawn object
        Instantiate(toSpawn, spawnPos, Quaternion.identity, gameObject.transform);
    }

    private Vector2 RandomDirection()
    {
        int choice = Mathf.FloorToInt(Random.value * 3.99f);
        //выбрать направление
        switch (choice)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            default:
                return Vector2.right;
        }
    }
    private int NumberOfGrounds()
    {
        int count = 0;
        foreach (gridSpace space in grid)
        {
            if (space == gridSpace.ground)
            {
                count++;
            }
        }
        return count;
    }
}