using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace XMLValidator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string GetFilePath(object sender, EventArgs e, string file_extension)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
              //  MessageBox.Show(file_extension);
                openFileDialog.Filter = file_extension + " files (" + file_extension + ")|" + file_extension;
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }
         //   MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            return filePath;


        }
        private void button2_Click(object sender, EventArgs e)
        {

            string file_extension = "*.xml";

            xmltextbox.Text = GetFilePath(sender, e, file_extension);
            if (XML_Validator(xmltextbox.Text)) { 
                label2.Text= "VALID";
                label2.ForeColor = Color.Green;
            } else
            {
                label2.Text = "INVALID";
                label2.ForeColor = Color.Red;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string file_extension = "*.json";
            jsontextbox.Text = GetFilePath(sender, e, file_extension);

        }
        private Boolean XML_Validator(String filenamepath)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();

            string schemaFile = "Test.xsd";

            XmlTextReader schemaReader = new XmlTextReader(schemaFile);
            XmlSchema schema = XmlSchema.Read(schemaReader, SchemaValidationHandler);

            xmlDoc.Schemas.Add(schema);
            
            xmlDoc.Load(filenamepath);
            xmlDoc.Validate(DocumentValidationHandler);
            
            }
            catch (SystemException  e ){
               // MessageBox.Show(e.Message.ToString());
                MessageBox.Show(e.Message.ToString(), "Error: Parse 001X1816562C", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false; 
            }
            return true;
        }
        private static void SchemaValidationHandler(object sender, ValidationEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private static void DocumentValidationHandler(object sender, ValidationEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
    }
}

