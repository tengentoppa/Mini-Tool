using GPK.Lib.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SqlGenerater_7_遊戲清單
{
    class Program
    {
        static List<GameInfo> GameInfos;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var gst = GameSupplierType.BG;
            GameInfos = new List<GameInfo>
            {
                // 電腦版
                new GameInfo("17","基蒂的双胞胎","Kitty Twins","17.png",1,$"{gst}"),
                new GameInfo("18","特斯拉","Tesla","18.png",1,$"{gst}"),
                new GameInfo("19","达芬奇法典","DaVinci Codex","19.png",1,$"{gst}"),
                new GameInfo("20","克利奥帕特拉珠宝","Cleopatra Jewels","20.png",1,$"{gst}"),
                new GameInfo("21","亚特兰提斯的世界","Atlantis World","21.png",1,$"{gst}"),
                new GameInfo("22","水晶神秘","Crystal Mystery","22.png",1,$"{gst}"),
                new GameInfo("23","五星级豪华场","Five Star Luxury","23.png",1,$"{gst}"),
                new GameInfo("24","财源滚滚","More Cash","24.png",1,$"{gst}"),
                new GameInfo("25","种钱得钱","Money Farm","25.png",1,$"{gst}"),
                new GameInfo("26","龙女","Dragon Lady","26.png",1,$"{gst}"),
                new GameInfo("27","燃烧的火焰","Burning Flame","27.png",1,$"{gst}"),
                new GameInfo("28","皇家宝石","Royal Gems","28.png",1,$"{gst}"),
                new GameInfo("29","火焰风暴","Storming Flame","29.png",1,$"{gst}"),
                new GameInfo("30","明星奖金","Star Cash","30.png",1,$"{gst}"),
                new GameInfo("37","宝玉","Jade Treasure","37.png",1,$"{gst}"),
                new GameInfo("38","88年财富","88 Riches","38.png",1,$"{gst}"),
                new GameInfo("39","国王的财富","King Of Wealth","39.png",1,$"{gst}"),
                new GameInfo("40","幸运的狮子","Fortune Lions","40.png",1,$"{gst}"),
                new GameInfo("41","拉美西斯的宝藏","Ramses Treasure","41.png",1,$"{gst}"),
                new GameInfo("42","卡里古拉","Caligula","42.png",1,$"{gst}"),
                new GameInfo("43","寻金之旅","Golden Dragon","43.png",1,$"{gst}"),
                new GameInfo("44","幸运的婴儿","Lucky Babies","44.png",1,$"{gst}"),
                new GameInfo("45","三王","Three Kings","45.png",1,$"{gst}"),
                new GameInfo("46","雷声鸟","Thunder Bird","46.png",1,$"{gst}"),
                new GameInfo("47","魔龙","Magic Dragon","47.png",1,$"{gst}"),
                new GameInfo("48","德州骑警的奖励","Texas Rangers Reward","48.png",1,$"{gst}"),
                new GameInfo("49","种钱得钱2","Money Farm 2","49.png",1,$"{gst}"),
                new GameInfo("50","老虎的心","Tiger Heart","50.png",1,$"{gst}"),
                new GameInfo("51","城堡血","Castle Blood","51.png",1,$"{gst}"),
                new GameInfo("91","海之女皇","Queen Of The Seas","91.png",1,$"{gst}"),
                new GameInfo("93","皇帝的财富","Emperors Wealth","93.png",1,$"{gst}"),
                new GameInfo("94","斗牛士","El Toreo","94.png",1,$"{gst}"),
                new GameInfo("105","BG 捕魚大師","Bg Fish Master","BgFish.png",1,$"{gst}"),
                // 手機版
                new GameInfo("17","基蒂的双胞胎","Kitty Twins","17.png",2,$"{gst}"),
                new GameInfo("18","特斯拉","Tesla","18.png",2,$"{gst}"),
                new GameInfo("19","达芬奇法典","DaVinci Codex","19.png",2,$"{gst}"),
                new GameInfo("20","克利奥帕特拉珠宝","Cleopatra Jewels","20.png",2,$"{gst}"),
                new GameInfo("21","亚特兰提斯的世界","Atlantis World","21.png",2,$"{gst}"),
                new GameInfo("22","水晶神秘","Crystal Mystery","22.png",2,$"{gst}"),
                new GameInfo("23","五星级豪华场","Five Star Luxury","23.png",2,$"{gst}"),
                new GameInfo("24","财源滚滚","More Cash","24.png",2,$"{gst}"),
                new GameInfo("25","种钱得钱","Money Farm","25.png",2,$"{gst}"),
                new GameInfo("26","龙女","Dragon Lady","26.png",2,$"{gst}"),
                new GameInfo("27","燃烧的火焰","Burning Flame","27.png",2,$"{gst}"),
                new GameInfo("28","皇家宝石","Royal Gems","28.png",2,$"{gst}"),
                new GameInfo("29","火焰风暴","Storming Flame","29.png",2,$"{gst}"),
                new GameInfo("30","明星奖金","Star Cash","30.png",2,$"{gst}"),
                new GameInfo("37","宝玉","Jade Treasure","37.png",2,$"{gst}"),
                new GameInfo("38","88年财富","88 Riches","38.png",2,$"{gst}"),
                new GameInfo("39","国王的财富","King Of Wealth","39.png",2,$"{gst}"),
                new GameInfo("40","幸运的狮子","Fortune Lions","40.png",2,$"{gst}"),
                new GameInfo("41","拉美西斯的宝藏","Ramses Treasure","41.png",2,$"{gst}"),
                new GameInfo("42","卡里古拉","Caligula","42.png",2,$"{gst}"),
                new GameInfo("43","寻金之旅","Golden Dragon","43.png",2,$"{gst}"),
                new GameInfo("44","幸运的婴儿","Lucky Babies","44.png",2,$"{gst}"),
                new GameInfo("45","三王","Three Kings","45.png",2,$"{gst}"),
                new GameInfo("46","雷声鸟","Thunder Bird","46.png",2,$"{gst}"),
                new GameInfo("47","魔龙","Magic Dragon","47.png",2,$"{gst}"),
                new GameInfo("48","德州骑警的奖励","Texas Rangers Reward","48.png",2,$"{gst}"),
                new GameInfo("49","种钱得钱2","Money Farm 2","49.png",2,$"{gst}"),
                new GameInfo("50","老虎的心","Tiger Heart","50.png",2,$"{gst}"),
                new GameInfo("51","城堡血","Castle Blood","51.png",2,$"{gst}"),
                new GameInfo("91","海之女皇","Queen Of The Seas","91.png",2,$"{gst}"),
                new GameInfo("93","皇帝的财富","Emperors Wealth","93.png",2,$"{gst}"),
                new GameInfo("94","斗牛士","El Toreo","94.png",2,$"{gst}"),
                new GameInfo("105","BG 捕魚大師","Bg Fish Master","BgFish.png",2,$"{gst}"),
            };

            string data = File.ReadAllText("Template/Template");
            string result;

            result = data
                .Replace("@GameSupplierType@", ((int)gst).ToString())
                .Replace("@GameDefinition@", GameDefinition(GameInfos))
                .Replace("@GameDefinitionCategory@", GameDefinitionCategory(GameInfos))
                .Replace("@GameDefinitionGameId@", GameDefinitionGameId(GameInfos))
                .Replace("@GameDefinitionImageTrace@", GameDefinitionImageTrace(GameInfos, gst));

            Console.WriteLine(result);
            File.WriteAllText("6.遊戲清單.sql", result);
            Console.ReadLine();
        }
        static string GameDefinition(List<GameInfo> Infos)
        {
            int i = 0;
            return
                "INSERT INTO [GameDefinition] (Id,GameSupplierType,GameKind,NameCn,NameEn,ImageFileName,ClickCount,IsDisabled,Memo,PlatformType) VALUES\n" +
                string.Join(
                $",\n",
                Infos.Select(d => $"(@maxDefinitionId+{++i},@GameSupplierType,2,{d.NameCn},{d.NameEn},{d.ImageFileName},0,{d.IsDisable},{d.Memo},{d.PlatformType})"
            ));
        }
        static string GameDefinitionCategory(List<GameInfo> Infos)
        {
            int i = 0;
            return
                "INSERT INTO GameDefinitionCategory (GameDefId,CategoryDefId) VALUES\n" +
                string.Join(
                $",\n",
                Infos.Select(d => $"(@maxDefinitionId+{++i}, 1)"
            ));
        }
        static string GameDefinitionGameId(List<GameInfo> Infos)
        {
            int i = 0;
            return
                "INSERT INTO [GameDefinitionGameId] ([GameDefId],[Key],[Value]) VALUES\n" +
                string.Join(
                $",\n",
                Infos.Select(d => $"(@maxDefinitionId+{++i}, N'gameId',{d.GameId})"
            ));
        }
        static string GameDefinitionImageTrace(List<GameInfo> Infos, GameSupplierType gst)
        {
            int i = 0;
            return
                "INSERT INTO GameDefinitionImageTrace ([FileName],[GameDefId],[Memo]) VALUES\n" +
                string.Join(
                $",\n",
                Infos.Select(d => $"({d.ImageFileName},@maxDefinitionId+{++i},N'{gst}')"
            ));
        }

        class GameInfo
        {
            string gameId;
            string nameCn;
            string nameEn;
            string imageFileName;
            string memo;
            public int GameKind { get; set; }
            public string GameId { set { gameId = value; } get { return $"N'{gameId}'"; } }
            public string NameCn { set { nameCn = value; } get { return $"N'{nameCn}'"; } }
            public string NameEn { set { nameEn = value; } get { return $"N'{nameEn}'"; } }
            public string ImageFileName { set { imageFileName = value; } get { return $"N'{imageFileName}'"; } }
            public int IsDisable { get; set; }
            public string Memo { set { memo = value; } get { return $"N'{memo}'"; } }
            public int PlatformType { get; set; }

            public GameInfo(string gameId, string nameCn, string nameEn, string imageFileName, int platformType, string memo = "", int gameKind = 2, int isDisable = 0)
            {
                GameId = gameId;
                NameCn = nameCn;
                NameEn = nameEn;
                ImageFileName = imageFileName;
                PlatformType = platformType;
                Memo = memo;
                GameKind = gameKind;
                IsDisable = isDisable;
            }
        }
    }
}
