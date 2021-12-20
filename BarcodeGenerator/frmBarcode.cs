using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

using IronBarCode;
using System.IO;

namespace BarcodeGenerator
{
    public partial class frmBarcode : Form
    {
        public frmBarcode()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {            
            string strData = "";
            strData += "{";            
            strData += "ID" + ":" + txtID.Text + ",";
            strData += "Name" + ":\""+ txtName.Text + "\"";
            strData += "}";

            var barcode = BarcodeWriter.CreateBarcode(strData, BarcodeEncoding.Code128);
            Bitmap bitmap = barcode.Render();
            pbBarCode.Image = bitmap;
            this.pbBarCode.Width = bitmap.Width;
            this.pbBarCode.Height = bitmap.Height;

            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Barcode";
            if (!Directory.Exists(appPath))
                Directory.CreateDirectory(appPath);
            pbBarCode.Image.Save(appPath + @"\Barcode" + Guid.NewGuid() + ".jpeg");

            pbBarCode.SizeMode = PictureBoxSizeMode.StretchImage;            
            pbBarCode.Height = 80;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\Barcode";
            if (!Directory.Exists(appPath))
                Directory.CreateDirectory(appPath);
            pbBarCode.Image.Save(appPath + @"\Barcode"+ Guid.NewGuid() +".jpeg");
        }
    }
}
