
namespace appticketcambio
{
    partial class Formetiqueta
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_pedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.lbl_boleta = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.lbl_cliente = new System.Windows.Forms.Label();
            this.lbl_pedido = new System.Windows.Forms.Label();
            this.txt_zpl = new System.Windows.Forms.TextBox();
            this.cboUsers = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_pedido
            // 
            this.txt_pedido.Location = new System.Drawing.Point(571, 13);
            this.txt_pedido.Name = "txt_pedido";
            this.txt_pedido.Size = new System.Drawing.Size(207, 27);
            this.txt_pedido.TabIndex = 0;
            this.txt_pedido.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pedido_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pedido:";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(571, 62);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(149, 29);
            this.btn_buscar.TabIndex = 2;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = true;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // lbl_boleta
            // 
            this.lbl_boleta.AutoSize = true;
            this.lbl_boleta.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_boleta.Location = new System.Drawing.Point(555, 144);
            this.lbl_boleta.Name = "lbl_boleta";
            this.lbl_boleta.Size = new System.Drawing.Size(175, 22);
            this.lbl_boleta.TabIndex = 3;
            this.lbl_boleta.Text = ".................................";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_fecha.Location = new System.Drawing.Point(555, 233);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(175, 22);
            this.lbl_fecha.TabIndex = 4;
            this.lbl_fecha.Text = ".................................";
            // 
            // lbl_cliente
            // 
            this.lbl_cliente.AutoSize = true;
            this.lbl_cliente.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_cliente.Location = new System.Drawing.Point(555, 185);
            this.lbl_cliente.Name = "lbl_cliente";
            this.lbl_cliente.Size = new System.Drawing.Size(175, 22);
            this.lbl_cliente.TabIndex = 5;
            this.lbl_cliente.Text = ".................................";
            // 
            // lbl_pedido
            // 
            this.lbl_pedido.AutoSize = true;
            this.lbl_pedido.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_pedido.Location = new System.Drawing.Point(555, 277);
            this.lbl_pedido.Name = "lbl_pedido";
            this.lbl_pedido.Size = new System.Drawing.Size(175, 22);
            this.lbl_pedido.TabIndex = 6;
            this.lbl_pedido.Text = ".................................";
            // 
            // txt_zpl
            // 
            this.txt_zpl.Location = new System.Drawing.Point(125, 63);
            this.txt_zpl.Multiline = true;
            this.txt_zpl.Name = "txt_zpl";
            this.txt_zpl.Size = new System.Drawing.Size(301, 247);
            this.txt_zpl.TabIndex = 7;
            // 
            // cboUsers
            // 
            this.cboUsers.BackColor = System.Drawing.SystemColors.HighlightText;
            this.cboUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsers.Font = new System.Drawing.Font("Segoe UI Black", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cboUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cboUsers.FormattingEnabled = true;
            this.cboUsers.Location = new System.Drawing.Point(125, 8);
            this.cboUsers.Name = "cboUsers";
            this.cboUsers.Size = new System.Drawing.Size(362, 33);
            this.cboUsers.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Usuario :";
            // 
            // Formetiqueta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboUsers);
            this.Controls.Add(this.txt_zpl);
            this.Controls.Add(this.lbl_pedido);
            this.Controls.Add(this.lbl_cliente);
            this.Controls.Add(this.lbl_fecha);
            this.Controls.Add(this.lbl_boleta);
            this.Controls.Add(this.btn_buscar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_pedido);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Formetiqueta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresión Ticket de Cambio";
            this.Load += new System.EventHandler(this.Formetiqueta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_pedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.Label lbl_boleta;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Label lbl_cliente;
        private System.Windows.Forms.Label lbl_pedido;
        private System.Windows.Forms.TextBox txt_zpl;
        private System.Windows.Forms.ComboBox cboUsers;
        private System.Windows.Forms.Label label2;
    }
}

