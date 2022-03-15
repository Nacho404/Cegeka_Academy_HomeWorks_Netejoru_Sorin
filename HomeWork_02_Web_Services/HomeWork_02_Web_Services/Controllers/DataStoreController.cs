using HomeWork_02_Web_Services.DataBaseConnection;
using HomeWork_02_Web_Services.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork_02_Web_Services.Controllers
{


    [Route("api/datastore/[controller]")]
    [ApiController]
    public class DataStoreController : ControllerBase
    {
		public OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = 'D:\Cegeka Academy\Teme\Tema[02] - [Web Services]\HomeWork_02_Web_Services\HomeWork_02_Web_Services\DB_file.accdb'");

		[HttpGet]
		public CarsTableDBModel Get()
		{

			CarsTableDBModel carsModels = new CarsTableDBModel();
			conn.Open();
			OleDbDataReader reader = null;
			OleDbCommand command = new OleDbCommand("SELECT * from CARS_MODELS", conn);

			reader = command.ExecuteReader();

			while (reader.Read())
            {
				//foreach(object element in reader)
				//            {
				//	carsModels.Add(element.ToString());
				//            }

				

				carsModels.Id = reader[0].ToString();
				carsModels.Series = reader[1].ToString();
				carsModels.Brand = reader[2].ToString();
                carsModels.Model_Name = reader[3].ToString();
                carsModels.Release_Year = reader[4].ToString();
                carsModels.Price = reader[5].ToString();

                
			}

			return carsModels;

		}
	}
}
