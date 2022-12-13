//create a qr code generator object with default settings
var qr = new QrCode();
//set the text to encode
qr.Text = "http://www.google.com";
//set the size of the QR code
qr.Size = 200;
//set the color of the QR code
qr.Color = Color.Black;
//set the background color of the QR code
qr.BackColor = Color.White;
//set the error correction level
qr.ErrorCorrect = ErrorCorrectLevel.M;
//set the margin
qr.Margin = 1;
//save the QR code as a bitmap
qr.Image.Save("C:\\qr.png", ImageFormat.Png);
