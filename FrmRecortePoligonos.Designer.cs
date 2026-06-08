namespace AlgoritmosDeDiscretizacion
{
    partial class FrmRecortePoligonos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblCoordenadas = new System.Windows.Forms.Label();
            this.tabla = new System.Windows.Forms.DataGridView();
            this.txtExplicacion = new System.Windows.Forms.RichTextBox();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.btnPasoPaso = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblVelocidad = new System.Windows.Forms.Label();
            this.trkVelocidad = new System.Windows.Forms.TrackBar();
            this.lblVelValor = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grpControles = new System.Windows.Forms.GroupBox();
            this.lblEcuacion = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.grpAlgoritmo = new System.Windows.Forms.GroupBox();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.grpExplicacion = new System.Windows.Forms.GroupBox();
            this.grpTabla = new System.Windows.Forms.GroupBox();
            this.grpGrafica = new System.Windows.Forms.GroupBox();
            this.tmrAnimacion = new System.Windows.Forms.Timer(this.components);
            this.grpVentana = new System.Windows.Forms.GroupBox();
            this.lblXMin = new System.Windows.Forms.Label();
            this.txtXMin = new System.Windows.Forms.TextBox();
            this.lblXMax = new System.Windows.Forms.Label();
            this.txtXMax = new System.Windows.Forms.TextBox();
            this.lblYMin = new System.Windows.Forms.Label();
            this.txtYMin = new System.Windows.Forms.TextBox();
            this.lblYMax = new System.Windows.Forms.Label();
            this.txtYMax = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkVelocidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.grpControles.SuspendLayout();
            this.grpAlgoritmo.SuspendLayout();
            this.grpExplicacion.SuspendLayout();
            this.grpTabla.SuspendLayout();
            this.grpGrafica.SuspendLayout();
            this.grpVentana.SuspendLayout();
            this.SuspendLayout();
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
            // tabla
            // 
            this.tabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabla.Location = new System.Drawing.Point(8, 22);
            this.tabla.Name = "tabla";
            this.tabla.RowHeadersWidth = 35;
            this.tabla.Size = new System.Drawing.Size(532, 110);
            this.tabla.TabIndex = 0;
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
            this.trkVelocidad.Value = 80;
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
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Location = new System.Drawing.Point(8, 22);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(880, 700);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Location = new System.Drawing.Point(-9, -16);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1480, 52);
            this.panelHeader.TabIndex = 10;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(383, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Recorte de Polígonos Interactivo";
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
            this.grpControles.Location = new System.Drawing.Point(3, 236);
            this.grpControles.Name = "grpControles";
            this.grpControles.Size = new System.Drawing.Size(548, 150);
            this.grpControles.TabIndex = 14;
            this.grpControles.TabStop = false;
            this.grpControles.Text = "Controles";
            // 
            // lblEcuacion
            // 
            this.lblEcuacion.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblEcuacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.lblEcuacion.Location = new System.Drawing.Point(3, 396);
            this.lblEcuacion.Name = "lblEcuacion";
            this.lblEcuacion.Size = new System.Drawing.Size(548, 24);
            this.lblEcuacion.TabIndex = 15;
            this.lblEcuacion.Text = "Instrucciones: Clic izquierdo coloca vértices. Clic derecho limpia.";
            // 
            // lblError
            // 
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.lblError.Location = new System.Drawing.Point(3, 424);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(548, 20);
            this.lblError.TabIndex = 16;
            // 
            // grpAlgoritmo
            // 
            this.grpAlgoritmo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpAlgoritmo.Controls.Add(this.cmbAlgoritmo);
            this.grpAlgoritmo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpAlgoritmo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpAlgoritmo.Location = new System.Drawing.Point(3, 46);
            this.grpAlgoritmo.Name = "grpAlgoritmo";
            this.grpAlgoritmo.Size = new System.Drawing.Size(548, 60);
            this.grpAlgoritmo.TabIndex = 11;
            this.grpAlgoritmo.TabStop = false;
            this.grpAlgoritmo.Text = "Selección de Algoritmo";
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbAlgoritmo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.cmbAlgoritmo.Items.AddRange(new object[] {
            "Sutherland-Hodgman",
            "Weiler-Atherton",
            "Cyrus-Beck"});
            this.cmbAlgoritmo.Location = new System.Drawing.Point(12, 25);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(520, 31);
            this.cmbAlgoritmo.TabIndex = 0;
            // 
            // grpExplicacion
            // 
            this.grpExplicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpExplicacion.Controls.Add(this.txtExplicacion);
            this.grpExplicacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpExplicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpExplicacion.Location = new System.Drawing.Point(3, 452);
            this.grpExplicacion.Name = "grpExplicacion";
            this.grpExplicacion.Size = new System.Drawing.Size(548, 200);
            this.grpExplicacion.TabIndex = 17;
            this.grpExplicacion.TabStop = false;
            this.grpExplicacion.Text = "Explicación del Algoritmo";
            // 
            // grpTabla
            // 
            this.grpTabla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpTabla.Controls.Add(this.tabla);
            this.grpTabla.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpTabla.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpTabla.Location = new System.Drawing.Point(3, 662);
            this.grpTabla.Name = "grpTabla";
            this.grpTabla.Size = new System.Drawing.Size(548, 140);
            this.grpTabla.TabIndex = 18;
            this.grpTabla.TabStop = false;
            this.grpTabla.Text = "Tabla de Pasos de Recorte";
            // 
            // grpGrafica
            // 
            this.grpGrafica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpGrafica.Controls.Add(this.picCanvas);
            this.grpGrafica.Controls.Add(this.lblCoordenadas);
            this.grpGrafica.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpGrafica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpGrafica.Location = new System.Drawing.Point(563, 46);
            this.grpGrafica.Name = "grpGrafica";
            this.grpGrafica.Size = new System.Drawing.Size(896, 756);
            this.grpGrafica.TabIndex = 19;
            this.grpGrafica.TabStop = false;
            this.grpGrafica.Text = "Gráfica (Plano Cartesiano)";
            // 
            // grpVentana
            // 
            this.grpVentana.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.grpVentana.Controls.Add(this.lblXMin);
            this.grpVentana.Controls.Add(this.txtXMin);
            this.grpVentana.Controls.Add(this.lblXMax);
            this.grpVentana.Controls.Add(this.txtXMax);
            this.grpVentana.Controls.Add(this.lblYMin);
            this.grpVentana.Controls.Add(this.txtYMin);
            this.grpVentana.Controls.Add(this.lblYMax);
            this.grpVentana.Controls.Add(this.txtYMax);
            this.grpVentana.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.grpVentana.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.grpVentana.Location = new System.Drawing.Point(3, 116);
            this.grpVentana.Name = "grpVentana";
            this.grpVentana.Size = new System.Drawing.Size(548, 110);
            this.grpVentana.TabIndex = 20;
            this.grpVentana.TabStop = false;
            this.grpVentana.Text = "Ventana de Recorte (Límites)";
            // 
            // lblXMin
            // 
            this.lblXMin.AutoSize = true;
            this.lblXMin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblXMin.Location = new System.Drawing.Point(15, 30);
            this.lblXMin.Name = "lblXMin";
            this.lblXMin.Size = new System.Drawing.Size(52, 20);
            this.lblXMin.Text = "X Mín:";
            this.lblXMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // txtXMin
            // 
            this.txtXMin.BackColor = System.Drawing.Color.White;
            this.txtXMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtXMin.Location = new System.Drawing.Point(70, 27);
            this.txtXMin.Size = new System.Drawing.Size(90, 30);
            this.txtXMin.TabIndex = 1;
            this.txtXMin.Text = "-10";
            // 
            // lblXMax
            // 
            this.lblXMax.AutoSize = true;
            this.lblXMax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblXMax.Location = new System.Drawing.Point(200, 30);
            this.lblXMax.Name = "lblXMax";
            this.lblXMax.Size = new System.Drawing.Size(56, 20);
            this.lblXMax.Text = "X Máx:";
            this.lblXMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // txtXMax
            // 
            this.txtXMax.BackColor = System.Drawing.Color.White;
            this.txtXMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtXMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtXMax.Location = new System.Drawing.Point(260, 27);
            this.txtXMax.Size = new System.Drawing.Size(90, 30);
            this.txtXMax.TabIndex = 3;
            this.txtXMax.Text = "10";
            // 
            // lblYMin
            // 
            this.lblYMin.AutoSize = true;
            this.lblYMin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYMin.Location = new System.Drawing.Point(15, 68);
            this.lblYMin.Name = "lblYMin";
            this.lblYMin.Size = new System.Drawing.Size(52, 20);
            this.lblYMin.Text = "Y Mín:";
            this.lblYMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // txtYMin
            // 
            this.txtYMin.BackColor = System.Drawing.Color.White;
            this.txtYMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYMin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtYMin.Location = new System.Drawing.Point(70, 65);
            this.txtYMin.Size = new System.Drawing.Size(90, 30);
            this.txtYMin.TabIndex = 5;
            this.txtYMin.Text = "-10";
            // 
            // lblYMax
            // 
            this.lblYMax.AutoSize = true;
            this.lblYMax.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblYMax.Location = new System.Drawing.Point(200, 68);
            this.lblYMax.Name = "lblYMax";
            this.lblYMax.Size = new System.Drawing.Size(56, 20);
            this.lblYMax.Text = "Y Máx:";
            this.lblYMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            // 
            // txtYMax
            // 
            this.txtYMax.BackColor = System.Drawing.Color.White;
            this.txtYMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYMax.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtYMax.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.txtYMax.Location = new System.Drawing.Point(260, 65);
            this.txtYMax.Size = new System.Drawing.Size(90, 30);
            this.txtYMax.TabIndex = 7;
            this.txtYMax.Text = "10";
            // 
            // FrmRecortePoligonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 786);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.grpVentana);
            this.Controls.Add(this.grpControles);
            this.Controls.Add(this.lblEcuacion);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.grpAlgoritmo);
            this.Controls.Add(this.grpExplicacion);
            this.Controls.Add(this.grpTabla);
            this.Controls.Add(this.grpGrafica);
            this.Name = "FrmRecortePoligonos";
            this.Text = "Recorte de Polígonos";
            ((System.ComponentModel.ISupportInitialize)(this.tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkVelocidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.grpControles.ResumeLayout(false);
            this.grpControles.PerformLayout();
            this.grpAlgoritmo.ResumeLayout(false);
            this.grpExplicacion.ResumeLayout(false);
            this.grpTabla.ResumeLayout(false);
            this.grpGrafica.ResumeLayout(false);
            this.grpGrafica.PerformLayout();
            this.grpVentana.ResumeLayout(false);
            this.grpVentana.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCoordenadas;
        private System.Windows.Forms.DataGridView tabla;
        private System.Windows.Forms.RichTextBox txtExplicacion;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Button btnPasoPaso;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblVelocidad;
        private System.Windows.Forms.TrackBar trkVelocidad;
        private System.Windows.Forms.Label lblVelValor;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox grpControles;
        private System.Windows.Forms.Label lblEcuacion;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.GroupBox grpAlgoritmo;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.GroupBox grpExplicacion;
        private System.Windows.Forms.GroupBox grpTabla;
        private System.Windows.Forms.GroupBox grpGrafica;
        private System.Windows.Forms.Timer tmrAnimacion;
        private System.Windows.Forms.GroupBox grpVentana;
        private System.Windows.Forms.Label lblXMin;
        private System.Windows.Forms.TextBox txtXMin;
        private System.Windows.Forms.Label lblXMax;
        private System.Windows.Forms.TextBox txtXMax;
        private System.Windows.Forms.Label lblYMin;
        private System.Windows.Forms.TextBox txtYMin;
        private System.Windows.Forms.Label lblYMax;
        private System.Windows.Forms.TextBox txtYMax;
    }
}
