using GPK.Lib.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Mini_Tool
{
    enum HallType
    {
        [Description("捕魚")]
        Fish,
        [Description("真人")]
        Real,
        [Description("彩票")]
        Lottery,
        [Description("棋牌")]
        Board,
        [Description("虛擬運動")]
        VirtualSport,
        [Description("電子")]
        Slot,
        [Description("電競")]
        Esport,
        [Description("體育")]
        Sport,
    }
    enum HallCategory
    {
        彩票,
        棋牌,
        機率,
        視訊,
        體育,
    }
    partial class Program
    {
        const string FileName = "9.CasinoCash.sql";
        static readonly string TargetPath = @"C:\gjsoft\Document\SQL Script\";
        static void Main(string[] args)
        {
            var data = new List<SqlColSetting>
            {
                new SqlColSetting("Provider","NVARCHAR(50)",true),
                //new SqlColSetting("GameId","NVARCHAR(50)",true),
                //new SqlColSetting("BetId","NVARCHAR(50)",true),
                //new SqlColSetting("WagerCreationDateTime","DATETIME",true),
                //new SqlColSetting("PlayerId","NVARCHAR(50)",true),
                //new SqlColSetting("Currency","NVARCHAR(5)",false),
                //new SqlColSetting("StakeAmount","DECIMAL(18,2)",true),
                //new SqlColSetting("MemberExposure","DECIMAL(18,2)",false),
                //new SqlColSetting("PayoutAmount","DECIMAL(18,2)",false),
                //new SqlColSetting("WinLoss","DECIMAL(18,2)",true),
                //new SqlColSetting("OddsType","NVARCHAR(15)",false),
                //new SqlColSetting("WagerType","NVARCHAR(15)",false),
                //new SqlColSetting("Platform","NVARCHAR(15)",false),
                //new SqlColSetting("IsSettled","NVARCHAR(5)",false),
                //new SqlColSetting("IsConfirmed","NVARCHAR(5)",false),
                //new SqlColSetting("IsCancelled","NVARCHAR(5)",false),
                //new SqlColSetting("SettlementDateTime","DATETIME",false),
                //new SqlColSetting("BetTradeStatus","NVARCHAR(15)",false),
                //new SqlColSetting("BetTradeCommission","DECIMAL(18,2)",false),
                //new SqlColSetting("BetTradeBuyBackAmount","DECIMAL(18,2)",false),
                //new SqlColSetting("ComboType","NVARCHAR(30)",false),
                //new SqlColSetting("LastUpdatedDate","DATETIME",false),
                //new SqlColSetting("DetailItems","NVARCHAR(MAX)",false),
            };
            string result;
            result = DoAllThings("AC001", GameSupplierType.BG, GameCategoryType.BgSlot, HallType.Slot, data, "BetId");

            File.WriteAllText(TargetPath + FileName, result);

            System.Diagnostics.Process.Start(TargetPath);
        }
        static string DoAllThings(string site, GameSupplierType gst, GameCategoryType gct, HallType ht, List<SqlColSetting> data, string idName)
        {
            var gameSupplier = (int)gst;
            var gameHallSort = gameSupplier - 1;
            var gameHallName = gst.ToString();
            var gameHallTitleName = new System.Globalization.CultureInfo("es-ES").TextInfo.ToTitleCase(gameHallName.ToLower());
            var gameCategory = (int)gct;
            var discountName = gameHallTitleName + ht.ToString();
            var hallType = ht.ToString();
            var hallName = ht.GetDescriptionText();
            var hallCategory = TransToHallCategory(ht).ToString();

            string result = "";

            result += Use(site);
            result += GameHallInfo(gameSupplier, true, gameHallSort, gameHallName);
            result += GameHallCategory(gameCategory, hallName, hallCategory, gameSupplier, discountName);


            result += RawDataSet(gameSupplier, gameHallTitleName, hallType, idName, data);
            return result;
        }
        static HallCategory TransToHallCategory(HallType hallType)
        {
            switch (hallType)
            {
                case HallType.Board:
                    return HallCategory.棋牌;
                case HallType.Sport:
                case HallType.Esport:
                    return HallCategory.體育;
                case HallType.Slot:
                case HallType.Fish:
                case HallType.VirtualSport:
                    return HallCategory.機率;
                case HallType.Lottery:
                    return HallCategory.彩票;
                case HallType.Real:
                    return HallCategory.視訊;
                default:
                    throw new ArgumentException($"{hallType} 無對應的 HallCategory Enum");
            }
        }

        #region Static Zone
        static string Use(string station)
        {
            return
                $"---------------------- ★ 切換 DB CasinoCash ★ ----------------------\n" +
                $"USE [CasinoCash.{station}]\n" +
                "GO";
        }
        static string GameHallInfo(int gameSupplierType, bool isEnterable, int sort, string text, string urlText = null, string name = null)
        {
            urlText = urlText ?? text;
            name = name ?? text;
            return
                $"IF NOT EXISTS(SELECT 1 FROM GameHallInfo WHERE GameSupplier={gameSupplierType})\n" +
                $"	INSERT INTO [GameHallInfo] ([GameSupplier], [IsEnterable], [Sort], [Text], [UrlText], [Name]) VALUES\n" +
                $"		({gameSupplierType}, {Convert.ToInt32(isEnterable)}, {sort}, '{text}', '{urlText}', '{name}')\n" +
                $"GO";
        }
        static string GameHallCategory(int id, string name, string category, int gameHallId, string discountName, bool isMemberDiscount = true, string memberDiscountSp = "U_MemberDiscountAdd_V1")
        {
            return
                $"IF NOT EXISTS(SELECT 1 FROM GameHallCategory WHERE Id={id})\n" +
                $"	INSERT [dbo].[GameHallCategory] ([Id], [Name], [Category], [GameHallId], [DiscountName], [IsMemberDiscount], [MemberDiscountSP]) VALUES\n" +
                $"		({id}, N'{name}', N'{category}', {gameHallId}, N'{discountName}', {Convert.ToInt32(isMemberDiscount)}, N'{memberDiscountSp}')\n" +
                $"GO";
        }
        static string RawDataSet(int gameSupplierType, string gameHall, string gameType, string idName, List<SqlColSetting> data)
        {
            var template = File.ReadAllText(@"Template/Template");


            var betRecordRawColumn = string.Join(",\n", data.Select(d => $"\t[{d.ColumnName}] {d.DataType} {(d.NotNull ? "NOT NULL" : "")}")) + ",";

            var sspChangeInput = string.Join(",\n", data.Select(d => $"\t@{d.ColumnName} {d.DataType}")) + ",";

            var sspChangeTemp = string.Join(",\n", data.Select(d => $"\t@_{d.ColumnName} {d.DataType}")) + ",";

            var sspChangeTable2Temp = string.Join(",\n", data.Select(d => $"\t\t\t\t@_{d.ColumnName}=[{d.ColumnName}]"));

            var sspCheckInputNullValue = "\t\tOR " + string.Join("\n\t\tOR ", data.Where(d => d.NotNull).Select(d => $"@{d.ColumnName} IS NULL "));

            var sspChangeGetColumns = "\t\t\t\t" + string.Join(",\n\t\t\t\t", data.Select(d => $"[{d.ColumnName}]")) + ",";

            var sspChangeSetValues = "\t\t\t\t" + string.Join(",\n\t\t\t\t", data.Select(d => $"@{d.ColumnName}")) + ",";

            var sspChangeCompareTmpNInput = "\t\t\t\t\t" + string.Join(" AND\n\t\t\t\t\t",
                data.Select(d => d.NotNull ?
                    $"@_{d.ColumnName}=@{d.ColumnName}" :
                    $"ISNULL(@_{d.ColumnName},{d.Value4CompareWhenNull})=ISNULL(@{d.ColumnName},{d.Value4CompareWhenNull})"));

            var sspChangeUpdateTable = "\t\t\t\t\t" + string.Join(",\n\t\t\t\t\t", data.Select(d => $"[{d.ColumnName}]=@{d.ColumnName}"));

            template = template.Replace("@GameSupplierType@", gameSupplierType.ToString());
            template = template.Replace("@BetRecordRawDataTable@", $"{gameHall}BetRecordRawData{gameType}");
            template = template.Replace("@MainID@", idName);
            template = template.Replace("@BetRecordRawColumn@", betRecordRawColumn);
            template = template.Replace("@SSPChangeInput@", sspChangeInput);
            template = template.Replace("@SSPChangeTemp@", sspChangeTemp);
            template = template.Replace("@SSPChangeTable2Temp@", sspChangeTable2Temp);
            template = template.Replace("@SSPCheckInputNullValue@", sspCheckInputNullValue);
            template = template.Replace("@SSPChangeGetColumns@", sspChangeGetColumns);
            template = template.Replace("@SSPChangeSetValues@", sspChangeSetValues);
            template = template.Replace("@SSPChangeCompareTmpNInput@", sspChangeCompareTmpNInput);
            template = template.Replace("@SSPChangeUpdateTable@", sspChangeUpdateTable);

            return template;
        }
        #endregion

        class SqlColSetting
        {
            public string ColumnName;
            public string DataType;
            public bool NotNull;
            public string Value4CompareWhenNull;
            public SqlColSetting(string columnName, string dataType, bool notNull)
            {
                ColumnName = columnName;
                DataType = dataType;
                NotNull = notNull;
                if (!NotNull)
                {
                    Value4CompareWhenNull = DefaultValueSwitcher(DataType);
                }
            }
            string DefaultValueSwitcher(string dataType)
            {
                if (dataType.Contains("CHAR") || dataType.Contains("TEXT")) return "''";
                if (dataType.Contains("DECIMAL")) return "-999999.00";
                if (dataType.Contains("DATETIMEOFFSET")) return "0";
                if (dataType.Contains("DATETIME")) return "'1970-01-01 00:00:01'";

                throw new ArgumentException($"Unimplement SQL type: {dataType}");
            }
        }
    }
    public static class EnumExtensions
    {
        public static string GetDescriptionText(this Enum source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
             typeof(DescriptionAttribute), false);
            if (attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }
    }
}
