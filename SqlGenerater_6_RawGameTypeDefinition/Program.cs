using GPK.Lib.Enum;
using System;
using System.Collections.Generic;
using System.IO;

namespace SqlGenerater_6_RawGameTypeDefinition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string result =
                "USE CasinoDataCenter\n" +
                "GO\n";
            int gameSupplierType = (int)GameSupplierType.BG;

            int gameCategoryType = (int)GameCategoryType.BgSlot;
            var data = new List<RawGameInfo>
            {
                new RawGameInfo("基蒂的双胞胎","17","Slot"),
                new RawGameInfo("特斯拉","18","Slot"),
                new RawGameInfo("达芬奇法典","19","Slot"),
                new RawGameInfo("克利奥帕特拉珠宝","20","Slot"),
                new RawGameInfo("亚特兰提斯的世界","21","Slot"),
                new RawGameInfo("水晶神秘","22","Slot"),
                new RawGameInfo("五星级豪华场","23","Slot"),
                new RawGameInfo("财源滚滚","24","Slot"),
                new RawGameInfo("种钱得钱","25","Slot"),
                new RawGameInfo("龙女","26","Slot"),
                new RawGameInfo("燃烧的火焰","27","Slot"),
                new RawGameInfo("皇家宝石","28","Slot"),
                new RawGameInfo("火焰风暴","29","Slot"),
                new RawGameInfo("明星奖金","30","Slot"),
                new RawGameInfo("宝玉","37","Slot"),
                new RawGameInfo("88年财富","38","Slot"),
                new RawGameInfo("国王的财富","39","Slot"),
                new RawGameInfo("幸运的狮子","40","Slot"),
                new RawGameInfo("拉美西斯的宝藏","41","Slot"),
                new RawGameInfo("卡里古拉","42","Slot"),
                new RawGameInfo("寻金之旅","43","Slot"),
                new RawGameInfo("幸运的婴儿","44","Slot"),
                new RawGameInfo("三王","45","Slot"),
                new RawGameInfo("雷声鸟","46","Slot"),
                new RawGameInfo("魔龙","47","Slot"),
                new RawGameInfo("德州骑警的奖励","48","Slot"),
                new RawGameInfo("种钱得钱2","49","Slot"),
                new RawGameInfo("老虎的心","50","Slot"),
                new RawGameInfo("城堡血","51","Slot"),
                new RawGameInfo("海之女皇","91","Slot"),
                new RawGameInfo("皇帝的财富","93","Slot"),
                new RawGameInfo("斗牛士","94","Slot"),
            };
            result += InsertToRawGametypeDefinition(gameSupplierType, data);
            result += InsertToGameTypeSource(gameSupplierType, gameCategoryType, data);

            gameCategoryType = (int)GameCategoryType.BgFish;
            data = new List<RawGameInfo>
            {
                new RawGameInfo("BG 捕魚大師","105","Fish"),
            };
            result += InsertToRawGametypeDefinition(gameSupplierType, data);
            result += InsertToGameTypeSource(gameSupplierType, gameCategoryType, data);

            gameCategoryType = (int)GameCategoryType.BgLottery;

            data = new List<RawGameInfo>
            {
                new RawGameInfo("欢乐生肖","1001","Lottery"),
                new RawGameInfo("新疆时时彩","1003","Lottery"),
                new RawGameInfo("天津时时彩","1004","Lottery"),
                new RawGameInfo("秒秒时时彩","1006","Lottery"),
                new RawGameInfo("2分时时彩","1007","Lottery"),
                new RawGameInfo("5分时时彩","1008","Lottery"),
                new RawGameInfo("分分时时彩","1018","Lottery"),
                new RawGameInfo("十分时时彩","1020","Lottery"),
                new RawGameInfo("澳洲幸运5","1026","Lottery"),
                new RawGameInfo("河内5分彩","1027","Lottery"),
                new RawGameInfo("极速时时彩","1031","Lottery"),
                new RawGameInfo("QQ分分彩","1021","Lottery"),
                new RawGameInfo("北京5分彩","1022","Lottery"),
                new RawGameInfo("斯洛伐克5分彩","1023","Lottery"),
                new RawGameInfo("加拿大3.5分彩","1024","Lottery"),
                new RawGameInfo("腾讯分分彩","1025","Lottery"),
                new RawGameInfo("北京赛车","1401","Lottery"),
                new RawGameInfo("幸运飞艇","1402","Lottery"),
                new RawGameInfo("2分PK10","1404","Lottery"),
                new RawGameInfo("5分PK10","1405","Lottery"),
                new RawGameInfo("分分PK10","1418","Lottery"),
                new RawGameInfo("十分赛车","1420","Lottery"),
                new RawGameInfo("澳洲幸运10","1426","Lottery"),
                new RawGameInfo("极速赛车","1431","Lottery"),
                new RawGameInfo("北京28","1501","Lottery"),
                new RawGameInfo("加拿大28","1502","Lottery"),
                new RawGameInfo("斯洛伐克28","1503","Lottery"),
                new RawGameInfo("北京幸运28","1561","Lottery"),
                new RawGameInfo("5分28","1516","Lottery"),
                new RawGameInfo("3分28","1517","Lottery"),
                new RawGameInfo("分分28","1518","Lottery"),
                new RawGameInfo("极速28","1531","Lottery"),
                new RawGameInfo("加拿大幸运28","1562","Lottery"),
                new RawGameInfo("极速幸运28","1563","Lottery"),
                new RawGameInfo("安徽快3","1201","Lottery"),
                new RawGameInfo("江苏快3","1202","Lottery"),
                new RawGameInfo("吉林快3","1203","Lottery"),
                new RawGameInfo("2分快3","1205","Lottery"),
                new RawGameInfo("湖北快3","1206","Lottery"),
                new RawGameInfo("贵州快3","1207","Lottery"),
                new RawGameInfo("上海快3","1208","Lottery"),
                new RawGameInfo("广西快3","1209","Lottery"),
                new RawGameInfo("甘肃快3","1210","Lottery"),
                new RawGameInfo("北京快3","1211","Lottery"),
                new RawGameInfo("河北快3","1212","Lottery"),
                new RawGameInfo("5分快3","1213","Lottery"),
                new RawGameInfo("分分快3","1218","Lottery"),
                new RawGameInfo("十分快3","1220","Lottery"),
                new RawGameInfo("极速快3","1231","Lottery"),
                new RawGameInfo("香港六合彩","2001","Lottery"),
                new RawGameInfo("5分六合彩","2003","Lottery"),
                new RawGameInfo("3分六合彩","2018","Lottery"),
                new RawGameInfo("极速六合彩","2031","Lottery"),
                new RawGameInfo("广东11选5","1101","Lottery"),
                new RawGameInfo("江西11选5","1102","Lottery"),
                new RawGameInfo("上海11选5","1103","Lottery"),
                new RawGameInfo("山东11选5","1104","Lottery"),
                new RawGameInfo("湖北11选5","1105","Lottery"),
                new RawGameInfo("幸运农场","1301","Lottery"),
                new RawGameInfo("广东快乐十分","1302","Lottery"),
                new RawGameInfo("湖南快乐十分","1303","Lottery"),
                new RawGameInfo("北京快乐8","2101","Lottery"),
                new RawGameInfo("加拿大快乐8","2102","Lottery"),
                new RawGameInfo("台湾缤果","2103","Lottery"),
                new RawGameInfo("斯洛伐克快乐8","2104","Lottery"),
                new RawGameInfo("福彩3D","1801","Lottery"),
                new RawGameInfo("排列3","1901","Lottery"),
                new RawGameInfo("上海时时乐","1601","Lottery"),
            };
            result += InsertToRawGametypeDefinition(gameSupplierType, data);
            result += InsertToGameTypeSource(gameSupplierType, gameCategoryType, data);

            File.WriteAllText($"6.RawGameTypeDefinition.sql", result);
        }
        static string InsertToRawGametypeDefinition(int gameSupplierType, List<RawGameInfo> raws)
        {
            string result = "";

            foreach (var data in raws)
            {
                result +=
                    $"if not exists(select 1 from RawGameTypeDefinition where GameSupplierType={gameSupplierType}" +
                    $"{(data.RawKey1 == "null" ? "" : $" AND RawKey1 = {data.RawKey1}")}" +
                    $"{(data.RawKey2 == "null" ? "" : $" AND RawKey2 = {data.RawKey2}")}" +
                    $"{(data.RawKey3 == "null" ? "" : $" AND RawKey3 = {data.RawKey3}")}" +
                    $"{(data.RawKey4 == "null" ? "" : $" AND RawKey4 = {data.RawKey4}")}" +
                    $"{(data.RawKey5 == "null" ? "" : $" AND RawKey5 = {data.RawKey5}")}" +
                    $")\n" +
                    $"\tinsert into RawGameTypeDefinition values({gameSupplierType}, {data.RawKey1}, {data.RawKey2}, {data.RawKey3}, {data.RawKey4}, {data.RawKey5})\n";
            }
            result += "GO\n";
            return result;
        }
        static string InsertToGameTypeSource(int gameSupplierType, int gameCategoryType, List<RawGameInfo> raws)
        {
            string result = "";
            string query;
            foreach (var data in raws)
            {
                query = $"(select Id from RawGameTypeDefinition where GameSupplierType = {gameSupplierType}" +
                    $"{(data.RawKey1 == "null" ? "" : $" AND RawKey1 = {data.RawKey1}")}" +
                    $"{(data.RawKey2 == "null" ? "" : $" AND RawKey2 = {data.RawKey2}")}" +
                    $"{(data.RawKey3 == "null" ? "" : $" AND RawKey3 = {data.RawKey3}")}" +
                    $"{(data.RawKey4 == "null" ? "" : $" AND RawKey4 = {data.RawKey4}")}" +
                    $"{(data.RawKey5 == "null" ? "" : $" AND RawKey5 = {data.RawKey5}")}" +
                    $")";
                result +=
                    $"if not exists(select 1 from GameTypeSource where GameSupplierType={gameSupplierType} and GameCategoryType={gameCategoryType} and Code={query})\n" +
                    $"\tinsert into GameTypeSource values ({gameSupplierType},{gameCategoryType},{query}, {data.GameName},'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}',null)\n";
            }
            result += "GO\n";
            return result;
        }
        class RawGameInfo
        {
            private string gameName;
            private string rawKey1;
            private string rawKey2;
            private string rawKey3;
            private string rawKey4;
            private string rawKey5;

            public string GameName { get => gameName; set => gameName = $"N'{value ?? "N/A"}'"; }
            public string RawKey1 { get => rawKey1; set => rawKey1 = Value2Sql(value); }
            public string RawKey2 { get => rawKey2; set => rawKey2 = Value2Sql(value); }
            public string RawKey3 { get => rawKey3; set => rawKey3 = Value2Sql(value); }
            public string RawKey4 { get => rawKey4; set => rawKey4 = Value2Sql(value); }
            public string RawKey5 { get => rawKey5; set => rawKey5 = Value2Sql(value); }

            static string Value2Sql(string value)
            {
                return value == null ? "null" : $"N'{value}'";
            }

            public RawGameInfo(string gameName, string rawKey1 = null, string rawKey2 = null, string rawKey3 = null, string rawKey4 = null, string rawKey5 = null)
            {
                GameName = gameName;
                RawKey1 = rawKey1;
                RawKey2 = rawKey2;
                RawKey3 = rawKey3;
                RawKey4 = rawKey4;
                RawKey5 = rawKey5;
            }
        }
    }
}
