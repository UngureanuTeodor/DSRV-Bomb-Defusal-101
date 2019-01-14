using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypads : MonoBehaviour {
    public GameObject module_1;
    public GameObject module_2;
    public GameObject module_3;
    public GameObject module_4;

    List<int> column_1;
    List<int> column_2;
    List<int> column_3;
    List<int> column_4;
    List<int> column_5;
    List<int> column_6;

    int module_nw;
    int module_ne;
    int module_sw;
    int module_se;

    static int index_module_nw;
    static int index_module_ne;
    static int index_module_sw;
    static int index_module_se;

    public static List<int> order;

    void PopulateColumn(int column) {
        switch (column) {
            case 1: {
                column_1.Add(1);
                column_1.Add(2);
                column_1.Add(3);
                column_1.Add(4);
                column_1.Add(5);
                column_1.Add(6);
                column_1.Add(7);
                break;
            }
            case 2:
                {
                column_2.Add(8);
                column_2.Add(1);
                column_2.Add(7);
                column_2.Add(9);
                column_2.Add(10);
                column_2.Add(6);
                column_2.Add(11);
                break;
            }
            case 3:
                {
                column_3.Add(12);
                column_3.Add(13);
                column_3.Add(9);
                column_3.Add(14);
                column_3.Add(15);
                column_3.Add(3);
                column_3.Add(10);
                break;
            }
            case 4:
                {
                column_4.Add(16);
                column_4.Add(17);
                column_4.Add(18);
                column_4.Add(5);
                column_4.Add(14);
                column_4.Add(11);
                column_4.Add(19);
                break;
            }
            case 5:
                {
                column_5.Add(20);
                column_5.Add(19);
                column_5.Add(18);
                column_5.Add(21);
                column_5.Add(17);
                column_5.Add(22);
                column_5.Add(23);
                break;
            }
            case 6:
                {
                column_6.Add(16);
                column_6.Add(8);
                column_6.Add(24);
                column_6.Add(25);
                column_6.Add(20);
                column_6.Add(26);
                column_6.Add(27);
                break;
            }
            default: {
                break;
            }
        }
    }

    List<int> GetPoolElements(int column) {
        List<int> pool = new List<int>(); 

        switch (column) {
            case 1: {
                pool.Add(column_1[0]);
                pool.Add(column_1[1]);
                pool.Add(column_1[2]);
                pool.Add(column_1[3]);
                pool.Add(column_1[4]);
                pool.Add(column_1[5]);
                break;
            }
            case 2: {
                pool.Add(column_2[0]);
                pool.Add(column_2[1]);
                pool.Add(column_2[2]);
                pool.Add(column_2[3]);
                pool.Add(column_2[4]);
                pool.Add(column_2[5]);
                break;
            }
            case 3: {
                pool.Add(column_3[0]);
                pool.Add(column_3[1]);
                pool.Add(column_3[2]);
                pool.Add(column_3[3]);
                pool.Add(column_3[4]);
                pool.Add(column_3[5]);
                break;
            }
            case 4: {
                pool.Add(column_4[0]);
                pool.Add(column_4[1]);
                pool.Add(column_4[2]);
                pool.Add(column_4[3]);
                pool.Add(column_4[4]);
                pool.Add(column_4[5]);
                break;
            }
            case 5: {
                pool.Add(column_5[0]);
                pool.Add(column_5[1]);
                pool.Add(column_5[2]);
                pool.Add(column_5[3]);
                pool.Add(column_5[4]);
                pool.Add(column_5[5]);
                break;
            }
            case 6: {
                pool.Add(column_6[0]);
                pool.Add(column_6[1]);
                pool.Add(column_6[2]);
                pool.Add(column_6[3]);
                pool.Add(column_6[4]);
                pool.Add(column_6[5]);
                break;
            }
            default: {
                break;
            }
        }

        return pool;
    }

    static int Min(int a, int b, int c, int d) {
        if (a < b && a < c && a < d) return a;
        if (b < a && b < c && b < d) return b;
        if (c < a && c < b && c < d) return c;
        if (d < a && d < b && d < c) return d;

        return a;
    }

    static int Min(int a, int b, int c)
    {
        if (a < b && a < c) return a;
        if (b < a && b < c) return b;
        if (c < a && c < b) return c;

        return a;
    }

    static int Min(int a, int b)
    {
        if (a < b) return a;
        if (b < a) return b;

        return a;
    }

    public static int GetMinList() {
        int min = -1;

        if (order.Count == 4)
        {
            min = Min(order[0], order[1], order[2], order[3]);
        }
        else if (order.Count == 3)
        {
            min = Min(order[0], order[1], order[2]);
        }
        else if (order.Count == 2)
        {
            min = Min(order[0], order[1]);
        }
        else if (order.Count == 1)
        {
            min = order[0];
        }

        return min;
    }

    void GenerateRandomModule() {
        // (1,6)
        int randomColumn = Random.Range(1, 7);

        List<int> pool = GetPoolElements(randomColumn);
        List<int> pool_index = GetPoolElements(randomColumn);

        int randomRow;

        randomRow = Random.Range(0, pool.Count);
        module_nw = pool[randomRow];
        pool.RemoveAt(randomRow);

        randomRow = Random.Range(0, pool.Count);
        module_ne = pool[randomRow];
        pool.RemoveAt(randomRow);

        randomRow = Random.Range(0, pool.Count);
        module_sw = pool[randomRow];
        pool.RemoveAt(randomRow);

        randomRow = Random.Range(0, pool.Count);
        module_se = pool[randomRow];
        pool.RemoveAt(randomRow);

        for (int i = 0; i < pool_index.Count; i++) {
            if (pool_index[i] == module_nw) index_module_nw = i;
            if (pool_index[i] == module_ne) index_module_ne = i;
            if (pool_index[i] == module_sw) index_module_sw = i;
            if (pool_index[i] == module_se) index_module_se = i;
        }

        Material auxMaterial = (Material)Resources.Load("keypad_" + module_nw, typeof(Material));
        module_1.GetComponent<Renderer>().material = auxMaterial;

        auxMaterial = (Material)Resources.Load("keypad_" + module_ne, typeof(Material));
        module_2.GetComponent<Renderer>().material = auxMaterial;

        auxMaterial = (Material)Resources.Load("keypad_" + module_sw, typeof(Material));
        module_3.GetComponent<Renderer>().material = auxMaterial;

        auxMaterial = (Material)Resources.Load("keypad_" + module_se, typeof(Material));
        module_4.GetComponent<Renderer>().material = auxMaterial;

        order.Add(index_module_nw);
        order.Add(index_module_ne);
        order.Add(index_module_sw);
        order.Add(index_module_se);

        //Debug.Log(module_nw);
        //Debug.Log(module_ne);
        //Debug.Log(module_sw);
        //Debug.Log(module_se);

        Debug.Log(index_module_nw);
        Debug.Log(index_module_ne);
        Debug.Log(index_module_sw);
        Debug.Log(index_module_se);
    }

    void Init() {
        column_1 = new List<int>();
        column_2 = new List<int>();
        column_3 = new List<int>();
        column_4 = new List<int>();
        column_5 = new List<int>();
        column_6 = new List<int>();

        PopulateColumn(1);
        PopulateColumn(2);
        PopulateColumn(3);
        PopulateColumn(4);
        PopulateColumn(5);
        PopulateColumn(6);

        module_nw = 0;
        module_ne = 0;
        module_sw = 0;
        module_se = 0;

        index_module_nw = 0;
        index_module_ne = 0;
        index_module_sw = 0;
        index_module_se = 0;

        order = new List<int>();
    }

    // Use this for initialization
    void Awake () {
        Init();
        GenerateRandomModule();
    }

	// Update is called once per frame
	void Update () {
    }

    public int GetModule_0() { return module_nw; }
    public int GetModule_1() { return module_ne; }
    public int GetModule_2() { return module_sw; }
    public int GetModule_3() { return module_se; }

    public static int GetIndexModule_0() { return index_module_nw; }
    public static int GetIndexModule_1() { return index_module_ne; }
    public static int GetIndexModule_2() { return index_module_sw; }
    public static int GetIndexModule_3() { return index_module_se; }

    public static void PopFromOrder(int index) {
        if (order.Count > 1)
        {
            for (int i = 0; i < order.Count; i++)
            {
                if (order[i] == index)
                {
                    order.RemoveAt(i);
                }
            }
        }
    }
}