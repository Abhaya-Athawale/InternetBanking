using Customer.Controllers;
using Customer.Database;
using Customer.Entity;
using Customer.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Xunit;
using Xunit.Abstractions;

namespace Testing.Services
{
    public  class  _TestViewStatement
    {
        private readonly ITestOutputHelper output;

        public _TestViewStatement(ITestOutputHelper output)
        {
            this.output = output;
        }
        DBContext db = new DBContext();
        TransactionService t = new TransactionService();
        [Fact]
        public async Task InvalidType()
        {
            var res = t.ViewStatment(1, "InvalidType", DateTime.Parse("2022-10-10T04:59:08.758Z"), DateTime.Parse("2022-11-10T04:59:08.758Z"));
            res.Should().BeNull();


        }
        [Fact]
        public async Task FromDateGreaterThanToDate()
        {
            var res = t.ViewStatment(1, "InvalidType", DateTime.Parse("2022-12-10T04:59:08.758Z"), DateTime.Parse("2022-11-10T04:59:08.758Z"));
            res.Should().BeNull();


        }
        [Fact]
        public async Task Correct()
        {
            
            var res = t.ViewStatment(1, "Withdraw", DateTime.Parse("2022-01-10T04:59:08.758Z"), DateTime.Parse("11/10/2022 11:54:25 AM"));

            var expectedResult = viewCorrectStatemests(1, "Withdraw", DateTime.Parse("2022-01-10T04:59:08.758Z"), DateTime.Parse("11/10/2022 11:54:25 AM"));
            bool val = true;
            if (res.Count != expectedResult.Count)
                val = false;
            output.WriteLine(res.Count.ToString() +" "+expectedResult.Count.ToString());
            for(int i=0;i<res.Count; i++)
            {
                if (res[i].TransacType != expectedResult[i].TransacType || res[i].TransacDate != expectedResult[i].TransacDate || res[i].CustomerId != expectedResult[i].CustomerId || res[i].TransacAmnt != expectedResult[i].TransacAmnt || res[i].TransacId != expectedResult[i].TransacId)
                    val =false;

            }
            

            Assert.True(val);


        }
        public List<Transaction>  viewCorrectStatemests(int CusId, string type, DateTime From, DateTime To)
            {
            List<Transaction> transactions = new List<Transaction>();
            var tra = db.transactions;
            foreach (Transaction t in tra)
            {
                if (type == "" || type == null)
                {
                    if (t.TransacDate > From && t.TransacDate<To)
                        transactions.Add(t);
                }
                else
                {
                    if (t.TransacDate > From && t.TransacDate<To && t.TransacType == type)
                        transactions.Add(t);
                }
            }
            return transactions.OrderByDescending(i => i.TransacDate).ToList();
            }
        public string SerializeObject<T>( T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                StringBuilder sb = textWriter.GetStringBuilder();
                sb.Remove(0, sb.Length);
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
    }

}
