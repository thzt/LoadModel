using System.Data;

namespace LoadModel.DataAccess
{
    public static class DataBaseOperation
    {
        public static DataSet Query(int index)
        {
            var dataSet = new DataSet();

            if (index == 1)
            {
                dataSet.Tables.Add(new DataTable());

                dataSet.Tables[0].Columns.Add("Model 1 Field 1");
                dataSet.Tables[0].Columns.Add("Model 1 Field 2");

                dataSet.Tables[0].Rows.Add(new object[] { 1, "Tom" });

                return dataSet;
            }

            dataSet.Tables.Add(new DataTable());

            dataSet.Tables[0].Columns.Add("Model 2 Field 1");
            dataSet.Tables[0].Columns.Add("Model 2 Field 2");

            dataSet.Tables[0].Rows.Add(new object[] { true, "Football" });

            return dataSet;
        }

        public static void Save(dynamic model)
        {

        }
    }
}