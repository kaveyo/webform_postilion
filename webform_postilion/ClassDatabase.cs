using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webform_postilion
{
    public class ClassDatabase
    {
        public SqlConnection conn = new SqlConnection();

        public SqlCommand cmd = new SqlCommand();
        public string locate = @"Data Source=10.180.5.14;Initial Catalog=postcard;User ID =sa; Password=Password123;";
       public string locate1 = @"Data Source=10.180.5.14;Initial Catalog=postcard_portal_test;User ID =sa; Password=Password123;";
    }
}