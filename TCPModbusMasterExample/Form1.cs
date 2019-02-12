using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

using System.Net;
namespace TCPModbusMasterExample
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private string ipAddress;
        private int port;
        public byte[] receiveData;
        public byte[] sendData;
        NetworkStream stream;
        public bool connected = false;
        private int connectTimeout = 1000;
       // private byte[] crc;
        private uint transctionIdentifierInternal = 0;
        private byte[] transctionIdentifier = new byte[2];
        private byte[] protocolIdentifier = new byte[2];
        private byte[] length = new byte[2];
        private byte unitIdentifier = 0x01;
        private byte functionCode;
        private byte[] startingAddress = new byte[2];
        private byte[] quantity = new byte[2];


        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtIpAddress.Text == "" || txtPort.Text == "")
            {
                MessageBox.Show("Enter IP Address And Port");

            }
            else
            {
               
                    connect();
                    if (connected)
                    {
                        txtIpAddress.Enabled = false;
                        txtPort.Enabled = false;
                        btnDisconnect.Enabled = true;
                        btnConnect.Enabled = false;
                        MessageBox.Show("Server Connected");
                        txtCheckConnect.BackColor = System.Drawing.Color.Green;
                        txtCheckConnect.ForeColor = System.Drawing.Color.White;
                        txtCheckConnect.Text = "Connected to server";
                     
                        btnReadCoils.Enabled = true;
                        btnReadDiscreateInputs.Enabled = true;
                        btnReadInputRegisaters.Enabled = true;
                        btnReadHoldingRegisters.Enabled = true;
                        btnWriteMultipleCoils.Enabled =true;
                        btnWriteSingleCoil.Enabled = true;
                        btnWriteSingleRegister.Enabled = true;
                        btnWriteMultipleRegisters.Enabled = true;
                        lstReadDataFromServer.Enabled = true;
                        lstWriteDataToServer.Enabled = true;
                        txtStartAddress.Enabled = true;
                        txtStartAddress1.Enabled =true;
                        txtSize.Enabled = true;
                        btnClearAll.Enabled = true;
                        btnClearEntry.Enabled = true;
                        btnPrepareCoils.Enabled = true;
                        button2.Enabled = true;
                        txtPrepareCoils.Enabled = true;
                        txtPrepareRegisters.Enabled = true;


                    }
                
               
            }
        }
        public void connect()
        {
            try
            {
                client = new TcpClient();
                port = Int32.Parse(txtPort.Text);
                ipAddress = txtIpAddress.Text;
                var result = client.BeginConnect(ipAddress, port, null, null);
                var success = result.AsyncWaitHandle.WaitOne(connectTimeout);
                if (!success)
                {
                    MessageBox.Show("Connection time out");
                }

                client.EndConnect(result);
                stream = client.GetStream();
                stream.ReadTimeout = connectTimeout;
                connected = true;
            }
            catch(Exception se)
            {
                MessageBox.Show("Enter Valis IP Address and Port "+se.Message);
            }
        }
        public void disConnect()
        {
            if (connected)
            {
                stream.Close();
                client.Close();
                connected = false;
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            disConnect();
            if (!connected)
            {
                txtPort.Enabled = true;
                txtIpAddress.Enabled = true;
                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnReadCoils.Enabled = false;
                btnReadDiscreateInputs.Enabled = false;
                btnReadInputRegisaters.Enabled = false;
                btnReadHoldingRegisters.Enabled = false;
                btnWriteMultipleCoils.Enabled = false;
                btnWriteSingleCoil.Enabled = false;
                btnWriteSingleRegister.Enabled = false;
                btnWriteMultipleRegisters.Enabled = false;
                lstReadDataFromServer.Enabled = false;
                lstWriteDataToServer.Enabled = false;
                txtStartAddress.Enabled = false;
                txtStartAddress1.Enabled = false;
                txtSize.Enabled = false;
                btnClearAll.Enabled = false;
                btnClearEntry.Enabled = false;
                btnPrepareCoils.Enabled = false;
                button2.Enabled = false;
                txtPrepareCoils.Enabled = false;
                txtPrepareRegisters.Enabled = false;
                MessageBox.Show("server Disconnected");
                txtCheckConnect.Text = "Not Connected To Server";
                txtCheckConnect.BackColor = System.Drawing.Color.Red;

            }

        }

        private void btnPrepareCoils_Click(object sender, EventArgs e)
        {
            lstWriteDataToServer.Items.Add(txtPrepareCoils.Text);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            lstWriteDataToServer.Items.Add(txtPrepareRegisters.Text);
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            lstWriteDataToServer.Items.Clear();
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {

            int rowindex = lstWriteDataToServer.SelectedIndex;
            if (rowindex >= 0)
            {
                lstWriteDataToServer.Items.RemoveAt(rowindex);
            }
        }
        
      
        private void btnReadCoils_Click(object sender, EventArgs e)
        {
            if (txtStartAddress.Text == "" || txtSize.Text == "")
            {
                MessageBox.Show("Please Enter the Start Address And size");
            }
            else
            {
                try
                {
                    if (connected)
                    {
                        bool[] serverResponse = ReadCoils();
                        lstReadDataFromServer.Items.Clear();

                        for (int i = 0; i < serverResponse.Length; i++)
                        {
                            lstReadDataFromServer.Items.Add(serverResponse[i]);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Server Disconnected...Please to server");
                    }
                }

                catch (Exception se)
                {
                    MessageBox.Show("" + se.Message);
                }
            }
        }
        public void writeSingleCoil()
        {
            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Start Address");
            }
            else  {
                try
                {
                    int startaddress = Int32.Parse(txtStartAddress1.Text) - 1;
                    bool value = Boolean.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[0]));
                    byte[] coilValue = new byte[2];
                    this.transctionIdentifier = BitConverter.GetBytes((uint)transctionIdentifierInternal);
                    this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                    this.length = BitConverter.GetBytes((int)0x0006);
                    this.functionCode = 0x05;
                    this.startingAddress = BitConverter.GetBytes(startaddress);
                    if (value == true)
                    {
                        coilValue = BitConverter.GetBytes((int)0xFF00);
                    }
                    else
                    {
                        coilValue = BitConverter.GetBytes((int)0x0000);
                    }
                    Byte[] data = new byte[]{	this.transctionIdentifier[1],
							this.transctionIdentifier[0],
							this.protocolIdentifier[1],
							this.protocolIdentifier[0],
							this.length[1],
							this.length[0],
							this.unitIdentifier,
							this.functionCode,
							this.startingAddress[1],
							this.startingAddress[0],
							coilValue[1],
							coilValue[0],
                           
                            };
                    stream.Write(data, 0, data.Length);
                }
                catch(Exception e)
                {
                    MessageBox.Show(""+e.Message);
                }
            }
        }
        public void writeMultipleCoils()
        {
            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please enter Start Addess");
            }
            else
            {
                try
                {
                    int startAddress = Int32.Parse(txtStartAddress1.Text) - 1;

                    int valuesLength = lstWriteDataToServer.Items.Count;
                    bool[] values = new bool[valuesLength];
                    for (int i = 0; i < valuesLength; i++)
                    {
                        values[i] = Boolean.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[i]));
                    }
                    byte byteCount = (byte)((values.Length % 8 != 0 ? values.Length / 8 + 1 : (values.Length / 8)));
                    byte[] quantityOfOutputs = BitConverter.GetBytes((int)values.Length);
                    byte singleCoilValue = 0;
                    this.transctionIdentifier = BitConverter.GetBytes((uint)transctionIdentifierInternal);
                    this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                    this.length = BitConverter.GetBytes((int)(7 + (byteCount)));
                    this.functionCode = 0x0F;
                    this.startingAddress = BitConverter.GetBytes(startAddress);
                    Byte[] data = new byte[14 + 2 + (values.Length % 8 != 0 ? values.Length / 8 : (values.Length / 8) - 1)];
                    data[0] = this.transctionIdentifier[1];
                    data[1] = this.transctionIdentifier[0];
                    data[2] = this.protocolIdentifier[1];
                    data[3] = this.protocolIdentifier[0];
                    data[4] = this.length[1];
                    data[5] = this.length[0];
                    data[6] = this.unitIdentifier;
                    data[7] = this.functionCode;
                    data[8] = this.startingAddress[1];
                    data[9] = this.startingAddress[0];
                    data[10] = quantityOfOutputs[1];
                    data[11] = quantityOfOutputs[0];
                    data[12] = byteCount;
                    for (int i = 0; i < values.Length; i++)
                    {

                        if ((i % 8) == 0)
                        {
                            singleCoilValue = 0;
                        }
                        byte CoilValue;
                        if (values[i] == true)
                        {
                            CoilValue = 1;
                        }
                        else
                        {
                            CoilValue = 0;
                        }

                        singleCoilValue = (byte)((int)CoilValue << (i % 8) | (int)singleCoilValue);

                        data[13 + (i / 8)] = singleCoilValue;
                    }
                    stream.Write(data, 0, data.Length);
                }
                catch(Exception e)
                {
                    MessageBox.Show(""+e.Message);
                }
            }
        }

        public void writeMultipleRegisters()
        {
            if (txtStartAddress1.Text == "")
            {
                MessageBox.Show("Please Enter Start Adress");
            }
            else
            {try{
                int startAddress = Int32.Parse(txtStartAddress1.Text) - 1;

                int valuesLength = lstWriteDataToServer.Items.Count;
                int[] values = new int[valuesLength];
                for (int i = 0; i < valuesLength; i++)
                {
                    values[i] = Int16.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[i]));
                }
                byte byteCount = (byte)(values.Length * (sizeof(Int32)/8));
                byte[] quantityOfOutputs = BitConverter.GetBytes((int)values.Length);

                this.transctionIdentifier = BitConverter.GetBytes((uint)transctionIdentifierInternal);
                this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                this.length = BitConverter.GetBytes((int)(7 + values.Length * sizeof(Int16)/8));
                this.functionCode = 0x10;
                this.startingAddress = BitConverter.GetBytes(startAddress);
                Byte[] data = new byte[13 + 2 + values.Length * (sizeof(Int16)/8)];
                data[0] = this.transctionIdentifier[1];
                data[1] = this.transctionIdentifier[0];
                data[2] = this.protocolIdentifier[1];
                data[3] = this.protocolIdentifier[0];
                data[4] = this.length[1];
                data[5] = this.length[0];
                data[6] = this.unitIdentifier;
                data[7] = this.functionCode;
                data[8] = this.startingAddress[1];
                data[9] = this.startingAddress[0];
                data[10] = quantityOfOutputs[1];
                data[11] = quantityOfOutputs[0];
                data[12] = byteCount;

                for (int i = 0; i < values.Length; i++)
                {
                    byte[] singleRegisterValue = BitConverter.GetBytes((int)values[i]);
                    data[13 + i * (sizeof(Int16)/8)] = singleRegisterValue[1];
                    data[14 + i * (sizeof(Int16)/8)] = singleRegisterValue[0];
                }


                stream.Write(data, 0, data.Length);
            }
            catch(Exception e)
            {
                MessageBox.Show(""+e.Message);

            }
            }
        }
        public void writeSingleRegister()
        {   if(txtStartAddress1.Text=="")
        {
            MessageBox.Show("Please Enter Start Address Ans Size");
        }
        else
        {
            try{
                    int startaddress = Int32.Parse(txtStartAddress1.Text) - 1;
                    int value = Int16.Parse(lstWriteDataToServer.GetItemText(lstWriteDataToServer.Items[0]));
                    byte[] RegisterValue = new byte[2];
                    this.transctionIdentifier = BitConverter.GetBytes((uint)transctionIdentifierInternal);
                    this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                    this.length = BitConverter.GetBytes((int)0x0006);
                    this.functionCode = 0x06;
                    this.startingAddress = BitConverter.GetBytes(startaddress);

                    RegisterValue = BitConverter.GetBytes((int)value);



                    Byte[] data = new byte[]{	this.transctionIdentifier[1],
							this.transctionIdentifier[0],
							this.protocolIdentifier[1],
							this.protocolIdentifier[0],
							this.length[1],
							this.length[0],
							this.unitIdentifier,
							this.functionCode,
							this.startingAddress[1],
							this.startingAddress[0],
							RegisterValue[1],
							RegisterValue[0],
                           
                            };
                    stream.Write(data, 0, data.Length);
                }
                catch(Exception e)
                {
                    MessageBox.Show(""+e.Message);
                }
            }
        }
        bool[] ReadDiscreateInputs()
        {
         
                    int startAddress = Int32.Parse(txtStartAddress.Text) - 1;
                    int quantity = Int16.Parse(txtSize.Text);
                    bool[] response;
                    if (txtStartAddress.Text == "" || txtSize.Text == "")
                    {
                        MessageBox.Show("start address and Size");
                    }




                    this.transctionIdentifier = BitConverter.GetBytes(transctionIdentifierInternal);
                    this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                    this.length = BitConverter.GetBytes((int)(0x0006));
                    this.functionCode = 0x02;
                    this.startingAddress = BitConverter.GetBytes(startAddress);
                    this.quantity = BitConverter.GetBytes(quantity);

                    byte[] data = new byte[] { 
                    this.transctionIdentifier[1],
                  this. transctionIdentifier[0],
                  this.protocolIdentifier[1],
                  this. protocolIdentifier[0],
                   this. length[1],
                   this.length[0],
                   this. unitIdentifier,
                   this. functionCode,
                   this.startingAddress[1],
                   this.startingAddress[0],
                   this.quantity[1],
                    this.quantity[0],
                  
                };



                    if (client.Client.Connected)
                    {
                        stream.Write(data, 0, data.Length);
                    }
                    data = new byte[2100];
                    int numberofbytes = stream.Read(data, 0, data.Length);
                    receiveData = new byte[numberofbytes];

                    response = new bool[quantity];
                    for (int i = 0; i < quantity; i++)
                    {
                        int intData = data[9 + i / 8];
                        int mask = Convert.ToInt32(Math.Pow(2, (i % 8)));
                        response[i] = Convert.ToBoolean((intData & mask) / mask);
                    }



                    return (response);
            
           
        }
     
    
     bool[] ReadCoils()
     {



     int startAddress;
     int quantity;
         bool[] response;
         
    startAddress = Int32.Parse(txtStartAddress.Text) - 1;
            quantity = Int32.Parse(txtSize.Text);
            




                 this.transctionIdentifier = BitConverter.GetBytes(transctionIdentifierInternal);
                 this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                 this.length = BitConverter.GetBytes((int)(0x0006));
                 this.functionCode = 0x01;
                 this.startingAddress = BitConverter.GetBytes(startAddress);
                 this.quantity = BitConverter.GetBytes(quantity);

                 byte[] data = new byte[] { 
                    this.transctionIdentifier[1],
                  this. transctionIdentifier[0],
                  this.protocolIdentifier[1],
                  this. protocolIdentifier[0],
                   this. length[1],
                   this.length[0],
                   this. unitIdentifier,
                   this. functionCode,
                   this.startingAddress[1],
                   this.startingAddress[0],
                   this.quantity[1],
                    this.quantity[0],
                  
                };



                 if (client.Client.Connected)
                 {
                     stream.Write(data, 0, data.Length);
                 }
                 data = new byte[2100];
                 int numberofbytes = stream.Read(data, 0, data.Length);
                 receiveData = new byte[numberofbytes];

                 response = new bool[quantity];
                 for (int i = 0; i < quantity; i++)
                 {
                     int intData = data[9 + i / 8];
                     int mask = Convert.ToInt32(Math.Pow(2, (i % 8)));
                     response[i] = Convert.ToBoolean((intData & mask) / mask);
                 }



                 return (response);
           
     }
     int[] ReadInputRegisters()
     {


         
             int startAddress = Int32.Parse(txtStartAddress.Text) - 1;
             int quantity = Int32.Parse(txtSize.Text);
             int[] response;





             this.transctionIdentifier = BitConverter.GetBytes(transctionIdentifierInternal);
             this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
             this.length = BitConverter.GetBytes((int)(0x0006));
             this.functionCode = 0x04;
             this.startingAddress = BitConverter.GetBytes(startAddress);
             this.quantity = BitConverter.GetBytes(quantity);

             byte[] data = new byte[] { 
                    this.transctionIdentifier[1],
                  this. transctionIdentifier[0],
                  this.protocolIdentifier[1],
                  this. protocolIdentifier[0],
                   this. length[1],
                   this.length[0],
                   this. unitIdentifier,
                   this. functionCode,
                   this.startingAddress[1],
                   this.startingAddress[0],
                   this.quantity[1],
                    this.quantity[0],
                  
                };



             if (client.Client.Connected)
             {
                 stream.Write(data, 0, data.Length);
             }
             data = new byte[2100];
             int numberofbytes = stream.Read(data, 0, data.Length);
             receiveData = new byte[numberofbytes];

             response = new int[quantity];
             for (int i = 0; i < quantity; i++)
             {
                 byte lowByte;
                 byte highByte;
                 highByte = data[9 + i * 2];
                 lowByte = data[9 + i * 2 + 1];

                 data[9 + i * 2] = lowByte;
                 data[9 + i * 2 + 1] = highByte;

                 response[i] = BitConverter.ToInt16(data, (9 + i * 2));

             }
             return (response);

         
        




        
     }
    
     int[] ReadHoldingRegisters()
     {
       
                 int startAddress = Int32.Parse(txtStartAddress.Text) - 1;
                 int quantity = Int32.Parse(txtSize.Text);
                 int[] response;





                 this.transctionIdentifier = BitConverter.GetBytes(transctionIdentifierInternal);
                 this.protocolIdentifier = BitConverter.GetBytes((int)0x0000);
                 this.length = BitConverter.GetBytes((int)(0x0006));
                 this.functionCode = 0x03;
                 this.startingAddress = BitConverter.GetBytes(startAddress);
                 this.quantity = BitConverter.GetBytes(quantity);

                 byte[] data = new byte[] { 
                    this.transctionIdentifier[1],
                  this. transctionIdentifier[0],
                  this.protocolIdentifier[1],
                  this. protocolIdentifier[0],
                   this. length[1],
                   this.length[0],
                   this. unitIdentifier,
                   this. functionCode,
                   this.startingAddress[1],
                   this.startingAddress[0],
                   this.quantity[1],
                    this.quantity[0],
                  
                };



                 if (client.Client.Connected)
                 {
                     stream.Write(data, 0, data.Length);
                 }
                 data = new byte[256];
                 int numberofbytes = stream.Read(data, 0, data.Length);
                 receiveData = new byte[numberofbytes];

                 response = new int[quantity];
                 for (int i = 0; i < quantity; i++)
                 {
                     byte lowByte;
                     byte highByte;
                     highByte = data[9 + i * 2];
                     lowByte = data[9 + i * 2 + 1];

                     data[9 + i * 2] = lowByte;
                     data[9 + i * 2 + 1] = highByte;

                     response[i] = BitConverter.ToInt16(data, (9 + i * 2));

                 }
                 return (response);

             
            
      
         

     }
    
     
     public static UInt16 calculateCRC(byte[] data, UInt16 numberOfBytes)
     {
         ushort Polynominal = 0x1021;
         ushort InitValue = 0x0;

         ushort i, j, index = 0;
         ushort CRC = InitValue;
         ushort Remainder, tmp, short_c;
         for (i = 0; i < numberOfBytes; i++)
         {
             short_c = (ushort)(0x00ff & (ushort)data[index]);
             tmp = (ushort)((CRC >> 8) ^ short_c);
             Remainder = (ushort)(tmp << 8);
             for (j = 0; j < 8; j++)
             {

                 if ((Remainder & 0x8000) != 0)
                 {
                     Remainder = (ushort)((Remainder << 1) ^ Polynominal);
                 }
                 else
                 {
                     Remainder = (ushort)(Remainder << 1);
                 }
             }

             CRC = (ushort)((CRC << 8) ^ Remainder);
             index++;
         }
         return CRC;

     }
        private void btnReadDiscreateInputs_Click(object sender, EventArgs e)
        {

            try
            {
                if (connected)
                {
                    bool[] serverResponse = ReadDiscreateInputs();
                    lstReadDataFromServer.Items.Clear();

                    for (int i = 0; i < serverResponse.Length; i++)
                    {
                        lstReadDataFromServer.Items.Add(serverResponse[i]);
                    }


                }
                else
                {
                    MessageBox.Show("Server Disconnected...Please Connect to server");
                }
            }
            catch(Exception se)
            {
                MessageBox.Show(""+se.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataRichTextBox.Enabled = false;
            txtCheckConnect.Enabled = false;
            btnDisconnect.Enabled = false;
            btnReadCoils.Enabled = false;
            btnReadDiscreateInputs.Enabled = false;
            btnReadInputRegisaters.Enabled = false;
            btnReadHoldingRegisters.Enabled = false;
            btnWriteMultipleCoils.Enabled = false;
            btnWriteSingleCoil.Enabled = false;
            btnWriteSingleRegister.Enabled = false;
            btnWriteMultipleRegisters.Enabled = false;
            lstReadDataFromServer.Enabled = false;
            lstWriteDataToServer.Enabled = false;
            txtStartAddress.Enabled = false;
            txtStartAddress1.Enabled = false;
            txtSize.Enabled = false;
            btnClearAll.Enabled = false;
            btnClearEntry.Enabled = false;
            btnPrepareCoils.Enabled = false;
            button2.Enabled = false;
            txtPrepareCoils.Enabled = false;
            txtPrepareRegisters.Enabled = false;


        }
        private void Form1_Closing(object sender, EventArgs e)
        {
            disConnect();
        }

        private void btnReadHoldingRegisters_Click(object sender, EventArgs e)
        {
            if (txtStartAddress.Text == "" || txtSize.Text == "")
            {
                MessageBox.Show("Plsase Enter Start Addess and Size");
            } 
            else{
                try{
                if (connected)
            {
                int[] serverResponse = ReadHoldingRegisters();
                lstReadDataFromServer.Items.Clear();

                for (int i = 0; i < serverResponse.Length; i++)
                {
                    lstReadDataFromServer.Items.Add(serverResponse[i]);
                }


            }
            else
            {
                MessageBox.Show("Server Disconnected...Please to server");
            }
                }
                catch(Exception se)
                {
                    MessageBox.Show(""+se.Message);
                }
            }

        }

        private void btnReadInputRegisaters_Click(object sender, EventArgs e)
        {
            if(txtStartAddress.Text=="" || txtSize.Text=="")
            {
                MessageBox.Show("Please Enter Start Address and Size");
            }
            else
            {
                try{
            
            if (connected)
            {
                int[] serverResponse = ReadInputRegisters();
                lstReadDataFromServer.Items.Clear();

                for (int i = 0; i < serverResponse.Length; i++)
                {
                    lstReadDataFromServer.Items.Add(serverResponse[i]);
                }


            }
            else
            {
                MessageBox.Show("Server Disconnected...Please to server");
            }
                }
                catch(Exception se)
                {
                    MessageBox.Show(""+se.Message);
                }
            }
       
        }

       

        private void btnWriteSingleCoil_Click(object sender, EventArgs e)
        {

            if (connected)
            {
                writeSingleCoil();
                lstWriteDataToServer.Items.Clear();
            }
            else
            {
                MessageBox.Show("Server Not Connected Please Connect To server");
            }
            
        }

        public byte[] RegisterValue { get; set; }

        private void btnWriteSingleRegister_Click(object sender, EventArgs e)
        {
           if(connected)
           {
               writeSingleRegister();
               lstWriteDataToServer.Items.Clear();
           }
        }

        private void btnWriteMultipleCoils_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                writeMultipleCoils();
                lstWriteDataToServer.Items.Clear();
            }
        }

        private void btnWriteMultipleRegisters_Click(object sender, EventArgs e)
        {
            if (connected)
            {
                writeMultipleRegisters();
                lstWriteDataToServer.Items.Clear();
            }
        }
    }
}
