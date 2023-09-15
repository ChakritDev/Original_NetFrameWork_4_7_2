using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Text.Json;
using OriginalFrameWork4_7_2.Data;
using OriginalFrameWork4_7_2.Models;

namespace OriginalFrameWork4_7_2.Controllers
{
    public class EmployeeController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Employee
        public IHttpActionResult GetDbEmployee()
        {
            var data = db.DbEmployee;
            var jsonData = JsonConvert.SerializeObject(data.ToArray().ToList());
            return Ok(data);
            //return db.DbEmployee;

        }
        private string ConvertIQToJson(string xmlString) 
        {
            return xmlString;
            //string xmlString = '<string xmlns="http://schemas.microsoft.com/2003/10/Serialization/">[{"Id":1,"FirstName":"Chakrit","LastName":"Thonthuean","Gender":"Female","BirthDay":"2023-09-04T00:00:00","CreateDate":"2023-09-04T11:59:50","IsActived":true}]</string>';

            // Create an XmlReader to parse the XML string
            /*using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                reader.MoveToContent();

                // Read the inner text within the <string> tag
                string innerText = reader.ReadInnerXml();

                // Print the inner text without the <string> tag
                Console.WriteLine(innerText);
                return innerText;
            }*/
        }

        // GET: api/Employee/5
        [ResponseType(typeof(EmployeeModel))]
        public async Task<IHttpActionResult> GetEmployeeModel(int id)
        {
            EmployeeModel employeeModel = await db.DbEmployee.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            return Ok(employeeModel);
        }

        // PUT: api/Employee/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeModel(int id, EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeModel.Id)
            {
                return BadRequest();
            }

            db.Entry(employeeModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employee
        [ResponseType(typeof(EmployeeModel))]
        public async Task<IHttpActionResult> PostEmployeeModel(EmployeeModel employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DbEmployee.Add(employeeModel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = employeeModel.Id }, employeeModel);
        }

        // DELETE: api/Employee/5
        [ResponseType(typeof(EmployeeModel))]
        public async Task<IHttpActionResult> DeleteEmployeeModel(int id)
        {
            EmployeeModel employeeModel = await db.DbEmployee.FindAsync(id);
            if (employeeModel == null)
            {
                return NotFound();
            }

            db.DbEmployee.Remove(employeeModel);
            await db.SaveChangesAsync();

            return Ok(employeeModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeModelExists(int id)
        {
            return db.DbEmployee.Count(e => e.Id == id) > 0;
        }
    }
}