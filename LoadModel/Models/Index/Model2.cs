using System;
using System.Data;

using LoadModel.DataAccess;

namespace LoadModel.Models.Index
{
    public sealed class Model2 : ILoadModelInterface
    {
        public bool Sex { get; set; }

        public string Hobby { get; set; }

        public void Init(int index)
        {
            DataSet dataSet = DataBaseOperation.Query(index);

            Sex = Convert.ToBoolean(dataSet.Tables[0].Rows[0][0]);
            Hobby = dataSet.Tables[0].Rows[0][1].ToString();
        }

        public void Save()
        {
            bool sex = Sex;
            string hobby = Hobby;

            DataBaseOperation.Save(this);
        }
    }
}