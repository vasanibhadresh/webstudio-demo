using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace webstudio_demo.App_Code.PROPERTY
{
    public class Function
    {
        public Function()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static String addPrefix(String filename)
        {
            string pic_tmp = filename;
            string pic_ext = filename.Substring(pic_tmp.LastIndexOf('.'));
            string date = DateTime.Now.ToString();
            string[] name = date.Split(' ', '/', ':');
            string new_filename = "";
            for (int i = 0; i < name.Length; i++)
            {
                new_filename = new_filename + name[i];
            }

            Guid g = Guid.NewGuid();
            string random = g.ToString();

            String pic_file = random + new_filename + pic_ext;
            return pic_file;
        }

            

    }
}