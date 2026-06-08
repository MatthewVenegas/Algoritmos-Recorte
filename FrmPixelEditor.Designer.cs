namespace AlgoritmosDeDiscretizacion
{
    partial class FrmPixelEditor
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
            this.grpModo = new System.Windows.Forms.GroupBox();
            this.rdbDibujar = new System.Windows.Forms.RadioButton();
            this.rdbBorrar = new System.Windows.Forms.RadioButton();
            this.rdbSemilla = new System.Windows.Forms.RadioButton();
            this.grpDimensiones = new System.Windows.Forms.GroupBox();
            this.lblAncho = new System.Windows.Forms.Label();
            this.numAncho = new System.Windows.Forms.NumericUpDown();
            this.lblAlto = new System.Windows.Forms.Label();
            this.numAlto = new System.Windows.Forms.NumericUpDown();
            this.btnRedimensionar = new System.Windows.Forms.Button();
            this.grpControles = new System.Windows.Forms.GroupBox();
            this.btnRellenar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.trkVelocidad = new System.Windows.Forms.TrackBar();
            this.lblVelValor = new System.Windows.Forms.Label();
            this.grpExplicacion = new System.Windows.Forms.GroupBox();
            this.txtExplicacion = new System.Windows.Forms.RichTextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.grpGrafica = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.grpAlgoritmo.SuspendLayout();
            this.grpModo.SuspendLayout();
            this.grpDimensiones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlto)).BeginInit();
            this.grpControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkVelocidad)).BeginInit();
            this.grpExplicacion.SuspendLayout();
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
            this.lblTitulo.Size = new System.Drawing.Size(547, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Algoritmos de Relleno y Editor de Píxeles";
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
            this.grpAlgoritmo.Text = "Selección de Algoritmo de Relleno";
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAlgoritmo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cmbAlgoritmo.Items.AddRange(new object[] {
            "Flood Fill (BFS - 4 Conectores)",
            "Boundary Fill (DFS - Frontera)",
            "Scan Line Fill (Línea de Barrido)"});
            this.cmbAlgoritmo.Location = new System.Drawing.Point(12, 25);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(520, 31);
            this.cmbAlgoritmo.TabIndex = 0;
            this.cmbAlgoritmo.SelectedIndexChanged += new System.EventHandler(this.cmbAlgoritmo_SelectedIndexChanged);
            // 
            // grpModo
            // 
            this.grpModo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpModo.Controls.Add(this.rdbDibujar);
            this.grpModo.Controls.Add(this.rdbBorrar);
            this.grpModo.Controls.Add(this.rdbSemilla);
            this.grpModo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpModo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpModo.Location = new System.Drawing.Point(12, 128);
            this.grpModo.Name = "grpModo";
            this.grpModo.Size = new System.Drawing.Size(548, 65);
            this.grpModo.TabIndex = 2;
            this.grpModo.TabStop = false;
            this.grpModo.Text = "Modo de Edición";
            // 
            // rdbDibujar
            // 
            this.rdbDibujar.AutoSize = true;
            this.rdbDibujar.Checked = true;
            this.rdbDibujar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdbDibujar.Location = new System.Drawing.Point(20, 25);
            this.rdbDibujar.Name = "rdbDibujar";
            this.rdbDibujar.Size = new System.Drawing.Size(127, 25);
            this.rdbDibujar.TabIndex = 0;
            this.rdbDibujar.TabStop = true;
            this.rdbDibujar.Text = "Dibujar Borde";
            this.rdbDibujar.UseVisualStyleBackColor = true;
            // 
            // rdbBorrar
            // 
            this.rdbBorrar.AutoSize = true;
            this.rdbBorrar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdbBorrar.Location = new System.Drawing.Point(180, 25);
            this.rdbBorrar.Name = "rdbBorrar";
            this.rdbBorrar.Size = new System.Drawing.Size(120, 25);
            this.rdbBorrar.TabIndex = 1;
            this.rdbBorrar.Text = "Borrar Borde";
            this.rdbBorrar.UseVisualStyleBackColor = true;
            // 
            // rdbSemilla
            // 
            this.rdbSemilla.AutoSize = true;
            this.rdbSemilla.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.rdbSemilla.Location = new System.Drawing.Point(340, 25);
            this.rdbSemilla.Name = "rdbSemilla";
            this.rdbSemilla.Size = new System.Drawing.Size(171, 25);
            this.rdbSemilla.TabIndex = 2;
            this.rdbSemilla.Text = "Colocar Semilla (x,y)";
            this.rdbSemilla.UseVisualStyleBackColor = true;
            // 
            // grpDimensiones
            // 
            this.grpDimensiones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpDimensiones.Controls.Add(this.lblAncho);
            this.grpDimensiones.Controls.Add(this.numAncho);
            this.grpDimensiones.Controls.Add(this.lblAlto);
            this.grpDimensiones.Controls.Add(this.numAlto);
            this.grpDimensiones.Controls.Add(this.btnRedimensionar);
            this.grpDimensiones.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpDimensiones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpDimensiones.Location = new System.Drawing.Point(12, 199);
            this.grpDimensiones.Name = "grpDimensiones";
            this.grpDimensiones.Size = new System.Drawing.Size(548, 65);
            this.grpDimensiones.TabIndex = 3;
            this.grpDimensiones.TabStop = false;
            this.grpDimensiones.Text = "Dimensiones del Lienzo";
            // 
            // lblAncho
            // 
            this.lblAncho.AutoSize = true;
            this.lblAncho.Location = new System.Drawing.Point(15, 30);
            this.lblAncho.Name = "lblAncho";
            this.lblAncho.Size = new System.Drawing.Size(58, 20);
            this.lblAncho.TabIndex = 0;
            this.lblAncho.Text = "Ancho:";
            // 
            // numAncho
            // 
            this.numAncho.Location = new System.Drawing.Point(70, 26);
            this.numAncho.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numAncho.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAncho.Name = "numAncho";
            this.numAncho.Size = new System.Drawing.Size(89, 27);
            this.numAncho.TabIndex = 1;
            this.numAncho.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblAlto
            // 
            this.lblAlto.AutoSize = true;
            this.lblAlto.Location = new System.Drawing.Point(165, 30);
            this.lblAlto.Name = "lblAlto";
            this.lblAlto.Size = new System.Drawing.Size(43, 20);
            this.lblAlto.TabIndex = 2;
            this.lblAlto.Text = "Alto:";
            // 
            // numAlto
            // 
            this.numAlto.Location = new System.Drawing.Point(205, 26);
            this.numAlto.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numAlto.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAlto.Name = "numAlto";
            this.numAlto.Size = new System.Drawing.Size(120, 27);
            this.numAlto.TabIndex = 3;
            this.numAlto.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // btnRedimensionar
            // 
            this.btnRedimensionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.btnRedimensionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedimensionar.ForeColor = System.Drawing.Color.White;
            this.btnRedimensionar.Location = new System.Drawing.Point(340, 20);
            this.btnRedimensionar.Name = "btnRedimensionar";
            this.btnRedimensionar.Size = new System.Drawing.Size(180, 32);
            this.btnRedimensionar.TabIndex = 4;
            this.btnRedimensionar.Text = "Redimensionar";
            this.btnRedimensionar.UseVisualStyleBackColor = false;
            this.btnRedimensionar.Click += new System.EventHandler(this.btnRedimensionar_Click);
            // 
            // grpControles
            // 
            this.grpControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpControles.Controls.Add(this.btnRellenar);
            this.grpControles.Controls.Add(this.btnDetener);
            this.grpControles.Controls.Add(this.btnLimpiar);
            this.grpControles.Controls.Add(this.lblVelocidad);
            this.grpControles.Controls.Add(this.trkVelocidad);
            this.grpControles.Controls.Add(this.lblVelValor);
            this.grpControles.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpControles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpControles.Location = new System.Drawing.Point(12, 270);
            this.grpControles.Name = "grpControles";
            this.grpControles.Size = new System.Drawing.Size(548, 140);
            this.grpControles.TabIndex = 4;
            this.grpControles.TabStop = false;
            this.grpControles.Text = "Acciones y Animación";
            // 
            // btnRellenar
            // 
            this.btnRellenar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnRellenar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRellenar.ForeColor = System.Drawing.Color.White;
            this.btnRellenar.Location = new System.Drawing.Point(15, 25);
            this.btnRellenar.Name = "btnRellenar";
            this.btnRellenar.Size = new System.Drawing.Size(150, 38);
            this.btnRellenar.TabIndex = 0;
            this.btnRellenar.Text = "Rellenar";
            this.btnRellenar.UseVisualStyleBackColor = false;
            this.btnRellenar.Click += new System.EventHandler(this.btnRellenar_Click);
            // 
            // btnDetener
            // 
            this.btnDetener.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetener.ForeColor = System.Drawing.Color.White;
            this.btnDetener.Location = new System.Drawing.Point(180, 25);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(150, 38);
            this.btnDetener.TabIndex = 1;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = false;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnLimpiar.Location = new System.Drawing.Point(345, 25);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(180, 38);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar Lienzo";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblVelocidad
            // 
            this.lblVelocidad.AutoSize = true;
            this.lblVelocidad.Location = new System.Drawing.Point(15, 80);
            this.lblVelocidad.Name = "lblVelocidad";
            this.lblVelocidad.Size = new System.Drawing.Size(130, 20);
            this.lblVelocidad.TabIndex = 3;
            this.lblVelocidad.Text = "Intervalo (delay):";
            // 
            // trkVelocidad
            // 
            this.trkVelocidad.Location = new System.Drawing.Point(145, 75);
            this.trkVelocidad.Maximum = 300;
            this.trkVelocidad.Minimum = 1;
            this.trkVelocidad.Name = "trkVelocidad";
            this.trkVelocidad.Size = new System.Drawing.Size(320, 56);
            this.trkVelocidad.TabIndex = 4;
            this.trkVelocidad.TickFrequency = 30;
            this.trkVelocidad.Value = 30;
            this.trkVelocidad.Scroll += new System.EventHandler(this.trkVelocidad_Scroll);
            // 
            // lblVelValor
            // 
            this.lblVelValor.AutoSize = true;
            this.lblVelValor.Location = new System.Drawing.Point(475, 80);
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
            this.grpExplicacion.Location = new System.Drawing.Point(12, 476);
            this.grpExplicacion.Name = "grpExplicacion";
            this.grpExplicacion.Size = new System.Drawing.Size(548, 335);
            this.grpExplicacion.TabIndex = 7;
            this.grpExplicacion.TabStop = false;
            this.grpExplicacion.Text = "Explicación del Algoritmo";
            // 
            // txtExplicacion
            // 
            this.txtExplicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.txtExplicacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExplicacion.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtExplicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtExplicacion.Location = new System.Drawing.Point(8, 22);
            this.txtExplicacion.Name = "txtExplicacion";
            this.txtExplicacion.ReadOnly = true;
            this.txtExplicacion.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtExplicacion.Size = new System.Drawing.Size(532, 300);
            this.txtExplicacion.TabIndex = 0;
            this.txtExplicacion.Text = "";
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblInfo.Location = new System.Drawing.Point(12, 420);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(548, 24);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = "Semilla: No colocada  —  Bordes pintados: 0";
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblError.Location = new System.Drawing.Point(12, 448);
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
            this.grpGrafica.Size = new System.Drawing.Size(896, 749);
            this.grpGrafica.TabIndex = 8;
            this.grpGrafica.TabStop = false;
            this.grpGrafica.Text = "Lienzo Interactivo de Píxeles";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Location = new System.Drawing.Point(8, 22);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(880, 690);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.picCanvas_Paint);
            this.picCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.picCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.picCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // lblCoordenadas
            // 
            this.lblCoordenadas.AutoSize = true;
            this.lblCoordenadas.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCoordenadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblCoordenadas.Location = new System.Drawing.Point(8, 720);
            this.lblCoordenadas.Name = "lblCoordenadas";
            this.lblCoordenadas.Size = new System.Drawing.Size(234, 20);
            this.lblCoordenadas.TabIndex = 1;
            this.lblCoordenadas.Text = "Cursor: (—, —)  |  Estado Celda: —";
            // 
            // FrmPixelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1480, 833);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.grpAlgoritmo);
            this.Controls.Add(this.grpModo);
            this.Controls.Add(this.grpDimensiones);
            this.Controls.Add(this.grpControles);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.grpExplicacion);
            this.Controls.Add(this.grpGrafica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPixelEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editor de Píxeles e Interacción de Relleno";
            this.Load += new System.EventHandler(this.FrmPixelEditor_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.grpAlgoritmo.ResumeLayout(false);
            this.grpModo.ResumeLayout(false);
            this.grpModo.PerformLayout();
            this.grpDimensiones.ResumeLayout(false);
            this.grpDimensiones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlto)).EndInit();
            this.grpControles.ResumeLayout(false);
            this.grpControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkVelocidad)).EndInit();
            this.grpExplicacion.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox grpModo;
        private System.Windows.Forms.RadioButton rdbDibujar;
        private System.Windows.Forms.RadioButton rdbBorrar;
        private System.Windows.Forms.RadioButton rdbSemilla;
        private System.Windows.Forms.GroupBox grpDimensiones;
        private System.Windows.Forms.Label lblAncho;
        private System.Windows.Forms.NumericUpDown numAncho;
        private System.Windows.Forms.Label lblAlto;
        private System.Windows.Forms.NumericUpDown numAlto;
        private System.Windows.Forms.Button btnRedimensionar;
        private System.Windows.Forms.GroupBox grpControles;
        private System.Windows.Forms.Button btnRellenar;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.TrackBar trkVelocidad;
        private System.Windows.Forms.Label lblVelValor;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox grpExplicacion;
        private System.Windows.Forms.RichTextBox txtExplicacion;
        private System.Windows.Forms.GroupBox grpGrafica;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label lblCoordenadas;
    }
}