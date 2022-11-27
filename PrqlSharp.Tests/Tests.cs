using Xunit;

namespace PrqlSharp.Tests
{
    public class Tests
    {
        [Fact]
        public void ConvertPrqlToSqlTest()
        {
            var result = Prql.ToSql("from table1");
            Assert.NotNull(result);
            Assert.Equal("SELECT\n  table1.*\nFROM\n  table1", result);
        }

        [Fact]
        public void ErrorHandlingTest()
        {
            Assert.Throws<ArgumentException>(() => Prql.ToSql("from table1 | select col1, col2"));
        }

        [Fact]
        public void ConvertPrqlToJsonTest()
        {
            var result = Prql.ToJson("from table1");
            Assert.NotNull(result);
            Assert.StartsWith("{\"version\"", result);
        }

        [Fact]
        public void PrqlAstBackAndForthTest()
        {
            var jsonQuery = Prql.ToJson("from table1");
            var prqlQuery = Prql.FromJson(jsonQuery);
            var sqlQuery = Prql.ToSql(prqlQuery);
            Assert.NotNull(sqlQuery);
            Assert.Equal("SELECT\n  table1.*\nFROM\n  table1", sqlQuery);
        }
    }
}