using System;
using System.Data;

using LoadModel.DataAccess;

namespace LoadModel.Models.Index
{
    public sealed class Model1 : ILoadModelInterface
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public void Init(int index)
        {
            DataSet dataSet = DataBaseOperation.Query(index);

            ID = Convert.ToInt32(dataSet.Tables[0].Rows[0][0]);
            Name = dataSet.Tables[0].Rows[0][1].ToString();
        }

        public void Save()
        {
            int id = ID;
            string name = Name;

            DataBaseOperation.Save(this);
        }
    }
}