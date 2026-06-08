namespace AlgoritmosDeDiscretizacion
{
    partial class FrmCirculos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpAlgoritmo = new System.Windows.Forms.GroupBox();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.grpCentro = new System.Windows.Forms.GroupBox();
            this.lblXc = new System.Windows.Forms.Label();
            this.txtXc = new System.Windows.Forms.TextBox();
            this.lblYc = new System.Windows.Forms.Label();
            this.txtYc = new System.Windows.Forms.TextBox();
            this.grpRadio = new System.Windows.Forms.GroupBox();
            this.lblR = new System.Windows.Forms.Label();
            this.txtR = new System.Windows.Forms.TextBox();
            this.grpControles = new System.Windows.Forms.GroupBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.btnPasoPaso = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.trkVelocidad = new System.Windows.Forms.TrackBar();
            this.lblVelValor = new System.Windows.Forms.Label();
            this.grpExplicacion = new System.Windows.Forms.GroupBox();
            this.txtExplicacion = new System.Windows.Forms.RichTextBox();
            this.grpTabla = new System.Windows.Forms.GroupBox();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.grpGrafica = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.grpAlgoritmo.SuspendLayout();
            this.grpCentro.SuspendLayout();
            this.grpRadio.SuspendLayout();
            this.grpControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkVelocidad)).BeginInit();
            this.grpExplicacion.SuspendLayout();
            this.grpTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            this.grpGrafica.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1480, 52);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(523, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Algoritmos de Círculos — Rasterización";
            // 
            // grpAlgoritmo
            // 
            this.grpAlgoritmo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpAlgoritmo.Controls.Add(this.cmbAlgoritmo);
            this.grpAlgoritmo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpAlgoritmo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpAlgoritmo.Location = new System.Drawing.Point(12, 62);
            this.grpAlgoritmo.Name = "grpAlgoritmo";
            this.grpAlgoritmo.Size = new System.Drawing.Size(548, 60);
            this.grpAlgoritmo.TabIndex = 1;
            this.grpAlgoritmo.TabStop = false;
            this.grpAlgoritmo.Text = "Selección de Algoritmo";
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAlgoritmo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cmbAlgoritmo.Items.AddRange(new object[] {
            "Punto Medio (Bresenham Circular)",
            "Bresenham (f = x²+y²-r²)",
            "Trigonométrico (cos/sin)"});
            this.cmbAlgoritmo.Location = new System.Drawing.Point(12, 25);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(520, 31);
            this.cmbAlgoritmo.TabIndex = 0;
            this.cmbAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cmbAlgoritmo_SelectedIndexChanged);
            // 
            // grpCentro
            // 
            this.grpCentro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpCentro.Controls.Add(this.lblXc);
            this.grpCentro.Controls.Add(this.txtXc);
            this.grpCentro.Controls.Add(this.lblYc);
            this.grpCentro.Controls.Add(this.txtYc);
            this.grpCentro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpCentro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpCentro.Location = new System.Drawing.Point(12, 132);
            this.grpCentro.Name = "grpCentro";
            this.grpCentro.Size = new System.Drawing.Size(262, 110);
            this.grpCentro.TabIndex = 2;
            this.grpCentro.TabStop = false;
            this.grpCentro.Text = "Centro (Xc, Yc)";
            // 
            // lblXc
            // 
            this.lblXc.AutoSize = true;
            this.lblXc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblXc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblXc.Location = new System.Drawing.Point(15, 30);
            this.lblXc.Name = "lblXc";
            this.lblXc.Size = new System.Drawing.Size(30, 20);
            this.lblXc.TabIndex = 0;
            this.lblXc.Text = "Xc:";
            // 
            // txtXc
            // 
            this.txtXc.BackColor = System.Drawing.Color.White;
            this.txtXc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtXc.Location = new System.Drawing.Point(50, 27);
            this.txtXc.Name = "txtXc";
            this.txtXc.Size = new System.Drawing.Size(90, 30);
            this.txtXc.TabIndex = 1;
            this.txtXc.Text = "0";
            // 
            // lblYc
            // 
            this.lblYc.AutoSize = true;
            this.lblYc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblYc.Location = new System.Drawing.Point(15, 68);
            this.lblYc.Name = "lblYc";
            this.lblYc.Size = new System.Drawing.Size(28, 20);
            this.lblYc.TabIndex = 2;
            this.lblYc.Text = "Yc:";
            // 
            // txtYc
            // 
            this.txtYc.BackColor = System.Drawing.Color.White;
            this.txtYc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtYc.Location = new System.Drawing.Point(50, 65);
            this.txtYc.Name = "txtYc";
            this.txtYc.Size = new System.Drawing.Size(90, 30);
            this.txtYc.TabIndex = 3;
            this.txtYc.Text = "0";
            // 
            // grpRadio
            // 
            this.grpRadio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpRadio.Controls.Add(this.lblR);
            this.grpRadio.Controls.Add(this.txtR);
            this.grpRadio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpRadio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpRadio.Location = new System.Drawing.Point(286, 132);
            this.grpRadio.Name = "grpRadio";
            this.grpRadio.Size = new System.Drawing.Size(274, 110);
            this.grpRadio.TabIndex = 3;
            this.grpRadio.TabStop = false;
            this.grpRadio.Text = "Radio";
            // 
            // lblR
            // 
            this.lblR.AutoSize = true;
            this.lblR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblR.Location = new System.Drawing.Point(15, 30);
            this.lblR.Name = "lblR";
            this.lblR.Size = new System.Drawing.Size(20, 20);
            this.lblR.TabIndex = 0;
            this.lblR.Text = "r:";
            // 
            // txtR
            // 
            this.txtR.BackColor = System.Drawing.Color.White;
            this.txtR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtR.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtR.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtR.Location = new System.Drawing.Point(40, 27);
            this.txtR.Name = "txtR";
            this.txtR.Size = new System.Drawing.Size(90, 30);
            this.txtR.TabIndex = 1;
            this.txtR.Text = "5";
            // 
            // grpControles
            // 
            this.grpControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpControles.Controls.Add(this.btnGraficar);
            this.grpControles.Controls.Add(this.btnPasoPaso);
            this.grpControles.Controls.Add(this.btnLimpiar);
            this.grpControles.Controls.Add(this.lblVelocidad);
            this.grpControles.Controls.Add(this.trkVelocidad);
            this.grpControles.Controls.Add(this.lblVelValor);
            this.grpControles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpControles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpControles.Location = new System.Drawing.Point(12, 252);
            this.grpControles.Name = "grpControles";
            this.grpControles.Size = new System.Drawing.Size(548, 150);
            this.grpControles.TabIndex = 4;
            this.grpControles.TabStop = false;
            this.grpControles.Text = "Controles";
            // 
            // btnGraficar
            // 
            this.btnGraficar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnGraficar.FlatAppearance.BorderSize = 0;
            this.btnGraficar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraficar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGraficar.ForeColor = System.Drawing.Color.White;
            this.btnGraficar.Location = new System.Drawing.Point(12, 25);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(160, 38);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = false;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // btnPasoPaso
            // 
            this.btnPasoPaso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(172)))));
            this.btnPasoPaso.FlatAppearance.BorderSize = 0;
            this.btnPasoPaso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPasoPaso.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPasoPaso.ForeColor = System.Drawing.Color.White;
            this.btnPasoPaso.Location = new System.Drawing.Point(182, 25);
            this.btnPasoPaso.Name = "btnPasoPaso";
            this.btnPasoPaso.Size = new System.Drawing.Size(160, 38);
            this.btnPasoPaso.TabIndex = 1;
            this.btnPasoPaso.Text = "Paso a Paso";
            this.btnPasoPaso.UseVisualStyleBackColor = false;
            this.btnPasoPaso.Click += new System.EventHandler(this.btnPasoPaso_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnLimpiar.Location = new System.Drawing.Point(352, 25);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(160, 38);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblVelocidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblVelocidad.Location = new System.Drawing.Point(12, 80);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(156, 20);
            this.lblVelocidad.TabIndex = 3;
            this.lblVelocidad.Text = "Velocidad animación:";
            // 
            // trkVelocidad
            // 
            this.trkVelocidad.Location = new System.Drawing.Point(145, 75);
            this.trkVelocidad.Maximum = 300;
            this.trkVelocidad.Minimum = 1;
            this.trkVelocidad.Name = "trkVelocidad";
            this.trkVelocidad.Size = new System.Drawing.Size(330, 56);
            this.trkVelocidad.TabIndex = 4;
            this.trkVelocidad.TickFrequency = 30;
            this.trkVelocidad.Value = 60;
            this.trkVelocidad.Scroll += new System.EventHandler(this.trkVelocidad_Scroll);
            // 
            // lblVelValor
            // 
            this.lblVelValor.AutoSize = true;
            this.lblVelValor.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblVelValor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblVelValor.Location = new System.Drawing.Point(480, 80);
            this.lblVelValor.Name = "lblVelValor";
            this.lblVelValor.Size = new System.Drawing.Size(0, 20);
            this.lblVelValor.TabIndex = 5;
            // 
            // grpExplicacion
            // 
            this.grpExplicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpExplicacion.Controls.Add(this.txtExplicacion);
            this.grpExplicacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpExplicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpExplicacion.Location = new System.Drawing.Point(12, 468);
            this.grpExplicacion.Name = "grpExplicacion";
            this.grpExplicacion.Size = new System.Drawing.Size(548, 200);
            this.grpExplicacion.TabIndex = 7;
            this.grpExplicacion.TabStop = false;
            this.grpExplicacion.Text = "Explicación del Algoritmo";
            // 
            // txtExplicacion
            // 
            this.txtExplicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txtExplicacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExplicacion.Font = new System.Drawing.Font("Consolas", 8.5F);
            this.txtExplicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtExplicacion.Location = new System.Drawing.Point(8, 22);
            this.txtExplicacion.Name = "txtExplicacion";
            this.txtExplicacion.ReadOnly = true;
            this.txtExplicacion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtExplicacion.Size = new System.Drawing.Size(532, 170);
            this.txtExplicacion.TabIndex = 0;
            this.txtExplicacion.Text = "";
            // 
            // grpTabla
            // 
            this.grpTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpTabla.Controls.Add(this.tabla);
            this.grpTabla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTabla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpTabla.Location = new System.Drawing.Point(12, 678);
            this.grpTabla.Name = "grpTabla";
            this.grpTabla.Size = new System.Drawing.Size(548, 140);
            this.grpTabla.TabIndex = 8;
            this.grpTabla.TabStop = false;
            this.grpTabla.Text = "Tabla de Puntos Generados";
            // 
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(8, 22);
            this.tabla.Name = "tabla";
            this.tabla.RowHeadersWidth = 35;
            this.tabla.Size = new System.Drawing.Size(532, 110);
            this.tabla.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblInfo.Location = new System.Drawing.Point(12, 412);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(548, 24);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Círculo: x²+y²=r²  —  Parámetros: —";
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblError.Location = new System.Drawing.Point(12, 440);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(548, 20);
            this.lblError.TabIndex = 6;
            // 
            // grpGrafica
            // 
            this.grpGrafica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpGrafica.Controls.Add(this.picCanvas);
            this.grpGrafica.Controls.Add(this.lblCoordenadas);
            this.grpGrafica.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpGrafica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpGrafica.Location = new System.Drawing.Point(572, 62);
            this.grpGrafica.Name = "grpGrafica";
            this.grpGrafica.Size = new System.Drawing.Size(896, 756);
            this.grpGrafica.TabIndex = 9;
            this.grpGrafica.TabStop = false;
            this.grpGrafica.Text = "Gráfica (Plano Cartesiano)";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Location = new System.Drawing.Point(8, 22);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(880, 700);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            // 
            // lblCoordenadas
            // 
            this.lblCoordenadas.AutoSize = true;
            this.lblCoordenadas.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCoordenadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblCoordenadas.Location = new System.Drawing.Point(8, 728);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(105, 20);
            this.lblCoordenadas.TabIndex = 1;
            this.lblCoordenadas.Text = "Cursor: (—, —)";
            // 
            // FrmCirculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1480, 833);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.grpAlgoritmo);
            this.Controls.Add(this.grpCentro);
            this.Controls.Add(this.grpRadio);
            this.Controls.Add(this.grpControles);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.grpExplicacion);
            this.Controls.Add(this.grpTabla);
            this.Controls.Add(this.grpGrafica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCirculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Algoritmos de Círculos";
            this.Load += new System.EventHandler(this.FrmCirculos_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.grpAlgoritmo.ResumeLayout(false);
            this.grpCentro.ResumeLayout(false);
            this.grpCentro.PerformLayout();
            this.grpRadio.ResumeLayout(false);
            this.grpRadio.PerformLayout();
            this.grpControles.ResumeLayout(false);
            this.grpControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkVelocidad)).EndInit();
            this.grpExplicacion.ResumeLayout(false);
            this.grpTabla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            this.grpGrafica.ResumeLayout(false);
            this.grpGrafica.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpAlgoritmo;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.GroupBox grpCentro;
        private System.Windows.Forms.Label lblXc;
        private System.Windows.Forms.TextBox txtXc;
        private System.Windows.Forms.Label lblYc;
        private System.Windows.Forms.TextBox txtYc;
        private System.Windows.Forms.GroupBox grpRadio;
        private System.Windows.Forms.Label lblR;
        private System.Windows.Forms.TextBox txtR;
        private System.Windows.Forms.GroupBox grpControles;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Button btnPasoPaso;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.TrackBar trkVelocidad;
        private System.Windows.Forms.Label lblVelValor;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox grpExplicacion;
        private System.Windows.Forms.RichTextBox txtExplicacion;
        private System.Windows.Forms.GroupBox grpTabla;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.GroupBox grpGrafica;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label lblCoordenadas;
    }
}
