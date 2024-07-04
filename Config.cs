//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Config : MonoBehaviour {

    // 定義存放黑棋棋型的字典
    /* {“紀錄黑棋數量”,{“棋型代號”,(“棋型”, 分數)}} */
    public Dictionary<string, Dictionary<string, Tuple<string, int>>> valueModelXTest;

    // 定義存放白棋棋型的字典
    public Dictionary<string, Dictionary<string, Tuple<string, int>>> valueModelOTest;


    // Start is called before the first frame update
    void Start() {
        
    }


    /* 命名規則
     * 主棋子數量_主棋子隔開的數量_編號
     */
    void InitializeValueModels() {
        valueModelXTest = new Dictionary<string, Dictionary<string, Tuple<string, int>>> {
            { "5", new Dictionary<string, Tuple<string, int>>
                {
                    {"5", Tuple.Create("XXXXX", 100000)} //連五棋型
                }
            },
            { "4", new Dictionary<string, Tuple<string, int>>
                {
                    {"4p_0", Tuple.Create(" XXXX ", 4000)}, //活四
                    {"4p_0_1", Tuple.Create("OXXXX ", 2000)}, //活四
                    {"4p_0_1", Tuple.Create(" XXXXO", 2000)}, //活四


                    {"4_0_1", Tuple.Create(" XXXX", 100)}, //死四

                    /* 下面的棋型可以自己設計:D*/
                    {"4_0_2", Tuple.Create("XXXX ", 100)}, //死四
                    {"4_0_3", Tuple.Create("OXXXX ", 100)}, //死四
                    {"4_0_4", Tuple.Create(" XXXXO", 100)}, //死四

                    {"4_1_1", Tuple.Create("X XXX", 120)}, //死四-3
                    {"4_1_2", Tuple.Create("XXX X", 120)}, //死四-4

                    {"4_2_1", Tuple.Create("XX XX", 100)}, //死四
                }
            },
            // 3: 60down
            { "3", new Dictionary<string, Tuple<string, int>>
                {
                    {"3p_0", Tuple.Create("  XXX  ", 60)}, //活三
                    {"3_0_1", Tuple.Create("  XXX ", 30)}, //活三-2
                    /* 下面的棋型可以自己設計:D*/
                    // 都是活三
                    {"3_0_2", Tuple.Create(" XXX  ", 30)}, 
                    {"3_0_3", Tuple.Create(" XXX ", 25)}, 

                    {"3_0_4", Tuple.Create("O  XXX  ", 58)}, 
                    {"3_0_5", Tuple.Create("O  XXX ", 28)}, 
                    {"3_0_6", Tuple.Create("O XXX  ", 28)}, 
                    {"3_0_7", Tuple.Create("O XXX ", 23)}, 

                    {"3_0_8", Tuple.Create("  XXX  O", 58)}, 
                    {"3_0_9", Tuple.Create("  XXX O", 28)}, 
                    {"3_0_10", Tuple.Create(" XXX  O", 28)}, 
                    {"3_0_11", Tuple.Create(" XXX O", 23)}, 

                    {"3_0_12", Tuple.Create("O  XXX  O", 56)},
                    {"3_0_13", Tuple.Create("O  XXX O", 26)}, 
                    {"3_0_14", Tuple.Create("O XXX  O", 26)}, 
                    {"3_0_15", Tuple.Create("O XXX O", 21)}, 

                    // 主要空一格
                    {"3p_1", Tuple.Create("  XX X  ", 55)},
                    {"3_1_1", Tuple.Create("  XX X ", 25)}, 
                    {"3_1_2", Tuple.Create(" XX X  ", 25)}, 
                    {"3_1_3", Tuple.Create(" XX X ", 20)},

                    {"3_1_4", Tuple.Create("O  XX X  ", 53)},
                    {"3_1_5", Tuple.Create("O  XX X ", 23)}, 
                    {"3_1_6", Tuple.Create("O XX X  ", 23)}, 
                    {"3_1_7", Tuple.Create("O XX X ", 21)}, 

                    {"3_1_8", Tuple.Create("  XX X  O", 53)}, 
                    {"3_1_9", Tuple.Create("  XX X O", 23)}, 
                    {"3_1_10", Tuple.Create(" XX X  O", 23)}, 
                    {"3_1_11", Tuple.Create(" XX X O", 21)}, 

                    {"3_1_12", Tuple.Create("O  XX X  O", 51)}, 
                    {"3_1_13", Tuple.Create("O  XX X O", 21)}, 
                    {"3_1_14", Tuple.Create("O XX X  O", 21)}, 
                    {"3_1_15", Tuple.Create("O XX X O", 20)}, 

                    // 後兩個
                    {"3p_1", Tuple.Create("  X XX  ", 55)},
                    {"3_2_1", Tuple.Create("  X XX ", 25)},
                    {"3_2_2", Tuple.Create(" X XX  ", 25)},
                    {"3_2_3", Tuple.Create(" X XX ", 20)},

                    {"3_2_4", Tuple.Create("O  X XX  ", 53)},
                    {"3_2_5", Tuple.Create("O  X XX ", 23)},
                    {"3_2_6", Tuple.Create("O X XX  ", 23)},
                    {"3_2_7", Tuple.Create("O X XX ", 21)},

                    {"3_2_8", Tuple.Create("  X XX  O", 53)},
                    {"3_2_9", Tuple.Create("  X XX O", 23)},
                    {"3_2_10", Tuple.Create(" X XX  O", 23)},
                    {"3_2_11", Tuple.Create(" X XX O", 21)},

                    {"3_2_12", Tuple.Create("O  X XX  O", 51)},
                    {"3_2_13", Tuple.Create("O  X XX O", 21)},
                    {"3_2_14", Tuple.Create("O X XX  O", 21)},
                    {"3_2_15", Tuple.Create("O X XX O", 20)},

                    // 都空格
                    {"3p_1", Tuple.Create("  X X X  ", 53)},
                    {"3_2_1", Tuple.Create("  X X X ", 23)},
                    {"3_2_2", Tuple.Create(" X X X  ", 23)},
                    {"3_2_3", Tuple.Create(" X X X ", 20)},

                    {"3_2_4", Tuple.Create("O  X X X  ", 51)},
                    {"3_2_5", Tuple.Create("O  X X X ", 21)},
                    {"3_2_6", Tuple.Create("O X X X  ", 21)},
                    {"3_2_7", Tuple.Create("O X X X ", 20)},

                    {"3_2_8", Tuple.Create("  X X X  O", 51)},
                    {"3_2_9", Tuple.Create("  X X X O", 21)},
                    {"3_2_10", Tuple.Create(" X X X  O", 21)},
                    {"3_2_11", Tuple.Create(" X X X O", 20)},

                    {"3_2_12", Tuple.Create("O  X X X  O", 49)},
                    {"3_2_13", Tuple.Create("O  X X X O", 20)},
                    {"3_2_14", Tuple.Create("O X X X  O", 20)},
                    {"3_2_15", Tuple.Create("O X X X O", 20)},

                }
            },
            /* 下面的棋型可以自己設計:D*/
            // 2: 20 down
            { "2", new Dictionary<string, Tuple<string, int>>
                {
                    {"2p_0", Tuple.Create("   XX   ", 20)}, //活二

                    {"2_0_1", Tuple.Create("   XX  ", 18)}, //活二-2
                    {"2_0_2", Tuple.Create("  XX   ", 18)}, //活二-2

                    {"2_0_5", Tuple.Create("  XX  ", 16)}, //活二-3
                    {"2_0_6", Tuple.Create("  XX  ", 16)}, //活二-3
                    {"2_0_7", Tuple.Create("  XX ", 14)}, //活二-4
                    {"2_0_8", Tuple.Create(" XX  ", 14)}, //活二-4

                    // 白在左
                    {"2p_0_9", Tuple.Create("O   XX   ", 19)}, //活二

                    {"2_0_10", Tuple.Create("O   XX  ", 17)}, //活二-2
                    {"2_0_11", Tuple.Create("O  XX   ", 17)}, //活二-2

                    {"2_0_12", Tuple.Create("O  XX  ", 15)}, //活二-3
                    {"2_0_13", Tuple.Create("O  XX  ", 15)}, //活二-3
                    {"2_0_14", Tuple.Create("O  XX ", 13)}, //活二-4
                    {"2_0_15", Tuple.Create("O XX  ", 13)}, //活二-4

                    // 白在右
                    {"2p_0_9", Tuple.Create("   XX   O", 19)}, //活二

                    {"2_0_10", Tuple.Create("   XX  O", 17)}, //活二-2
                    {"2_0_11", Tuple.Create("  XX   O", 17)}, //活二-2

                    {"2_0_12", Tuple.Create("  XX  O", 15)}, //活二-3
                    {"2_0_13", Tuple.Create("  XX  O", 15)}, //活二-3
                    {"2_0_14", Tuple.Create("  XX O", 13)}, //活二-4
                    {"2_0_15", Tuple.Create(" XX  O", 13)}, //活二-4




                    {"2_0_9", Tuple.Create(" XX ", 3)}, //死二
                    {"2_0_10", Tuple.Create("  XX", 3)}, //死二
                    {"2_0_11", Tuple.Create("XX  ", 3)}, //死二
                }
            }
        };

        valueModelOTest = new Dictionary<string, Dictionary<string, Tuple<string, int>>>();
        foreach(var outer in valueModelXTest) { // 遍歷第一層字典
            var outerKey = outer.Key; // 得到第一層字典的Key
            var innerDic = outer.Value; // 得到第一層字典的Value (第二層字典)

            foreach(var inner in innerDic) { // 遍歷第二層字典
                var innerKey = inner.Key; // 得到第二層的Key(棋型的編號)
                var tupleValue = inner.Value; // 得到第二層字典的Value，<模型字串, int分數>的Tuple

                // 把Tuple的第一個元素中的'X'->'O' 'O'->'X'
                var newString = new string(tupleValue.Item1.Select(c => c == 'X' ? 'O' : c == 'O' ? 'X' : c).ToArray());
                var newTuple = Tuple.Create(newString, tupleValue.Item2); //得到一個替換後的新Tuple

                if (!valueModelOTest.ContainsKey(outerKey)) {//檢查valueModelOTest是否包含當前的第一層字典的Key
                    // 如果不包含，則創建一個新的內層(第二層)字典，並添加到valueModelOTest中
                    valueModelOTest[outerKey] = new Dictionary<string, Tuple<string, int>>();
                }

                // 取第二層字典的Value
                valueModelOTest[outerKey][innerKey] = newTuple;
            }
        }
    } 

    // 將字典轉換成List型態的函數
    private List<Dictionary<string, List<Tuple<string, int>>>> TransformModel(
                Dictionary<string, Dictionary<string, Tuple<string, int>>> model) {
        // 初始化轉換後的列表
        var transformedList = new List<Dictionary<string, List<Tuple<string, int>>>>();

        // 遍歷外層字典
        foreach (var outer in model) { 
            
            var innerDic = outer.Value; // 獲取內層字典
            //初始化轉換後的字典
            var transformedDic = new Dictionary<string, List<Tuple<string, int>>>() ;

            // 遍歷內層字典
            foreach(var inner in innerDic) {
                // 一個新的列表，包含一個元素是內層字典的value，也就是一個Tuple<string, int>
                var tupleList = new List<Tuple<string, int>> { inner.Value};

                // 將tupleList添加到transformedDic字典的Value，也就是Tuple<string, int>
                transformedDic[inner.Key] = tupleList;
            }

            // 轉換後的字典添加到transformedList，也就是型態 Dictionary<string, Tuple<string, int>>
            transformedList.Add(transformedDic);
        }
        return transformedList;
    }  


    // Update is called once per frame
    void Update() {
        
    }
}