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

using QRCoder;
using System.IO;

namespace BarcodeGenerator
{
    public partial class frmQRCode : Form
    {
        public frmQRCode()
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


            using(QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using(QRCodeData QRCodeData = qrGenerator.CreateQrCode(strData, QRCodeGenerator.ECCLevel.M, true))
            using (QRCode QRCode = new QRCode(QRCodeData))
            {
                pbQRCode.Image = QRCode.GetGraphic(20);
                this.pbQRCode.Size = new System.Drawing.Size(80, 80);
                this.pbQRCode.SizeMode = PictureBoxSizeMode.CenterImage;
                pbQRCode.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\QRCode";
            if (!Directory.Exists(appPath))
                Directory.CreateDirectory(appPath);
            pbQRCode.Image.Save(appPath + @"\QRCode"+ Guid.NewGuid() +".jpeg");
        }
    }
}
