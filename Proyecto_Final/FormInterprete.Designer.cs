namespace Proyecto_Final
{
    partial class FormInterprete
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tboxCodigoAAnalizar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReconocerElementos = new System.Windows.Forms.Button();
            this.btnValidarSintaxis = new System.Windows.Forms.Button();
            this.dGridTablaLexemas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEvaluar = new System.Windows.Forms.Button();
            this.btnPrograma1 = new System.Windows.Forms.Button();
            this.btnPrograma2 = new System.Windows.Forms.Button();
            this.lblCargarPrograma = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnPrograma3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGridTablaLexemas)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxCodigoAAnalizar
            // 
            this.tboxCodigoAAnalizar.Location = new System.Drawing.Point(33, 64);
            this.tboxCodigoAAnalizar.Multiline = true;
            this.tboxCodigoAAnalizar.Name = "tboxCodigoAAnalizar";
            this.tboxCodigoAAnalizar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tboxCodigoAAnalizar.Size = new System.Drawing.Size(365, 113);
            this.tboxCodigoAAnalizar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese su codigo a analizar";
            // 
            // btnReconocerElementos
            // 
            this.btnReconocerElementos.Location = new System.Drawing.Point(33, 228);
            this.btnReconocerElementos.Name = "btnReconocerElementos";
            this.btnReconocerElementos.Size = new System.Drawing.Size(160, 23);
            this.btnReconocerElementos.TabIndex = 2;
            this.btnReconocerElementos.Text = "Reconocer Elementos";
            this.btnReconocerElementos.UseVisualStyleBackColor = true;
            this.btnReconocerElementos.Click += new System.EventHandler(this.btnReconocerElementos_Click);
            // 
            // btnValidarSintaxis
            // 
            this.btnValidarSintaxis.Location = new System.Drawing.Point(33, 280);
            this.btnValidarSintaxis.Name = "btnValidarSintaxis";
            this.btnValidarSintaxis.Size = new System.Drawing.Size(160, 23);
            this.btnValidarSintaxis.TabIndex = 3;
            this.btnValidarSintaxis.Text = "Validar Sintaxis";
            this.btnValidarSintaxis.UseVisualStyleBackColor = true;
            this.btnValidarSintaxis.Click += new System.EventHandler(this.btnValidarSintaxis_Click);
            // 
            // dGridTablaLexemas
            // 
            this.dGridTablaLexemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridTablaLexemas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dGridTablaLexemas.Location = new System.Drawing.Point(447, 64);
            this.dGridTablaLexemas.Name = "dGridTablaLexemas";
            this.dGridTablaLexemas.Size = new System.Drawing.Size(295, 295);
            this.dGridTablaLexemas.TabIndex = 4;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Lexema";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Descripcion";
            this.Column2.Name = "Column2";
            // 
            // btnEvaluar
            // 
            this.btnEvaluar.Enabled = false;
            this.btnEvaluar.Location = new System.Drawing.Point(37, 357);
            this.btnEvaluar.Name = "btnEvaluar";
            this.btnEvaluar.Size = new System.Drawing.Size(75, 23);
            this.btnEvaluar.TabIndex = 6;
            this.btnEvaluar.Text = "Evaluar";
            this.btnEvaluar.UseVisualStyleBackColor = true;
            this.btnEvaluar.Click += new System.EventHandler(this.btnEvaluar_Click);
            // 
            // btnPrograma1
            // 
            this.btnPrograma1.Location = new System.Drawing.Point(243, 183);
            this.btnPrograma1.Name = "btnPrograma1";
            this.btnPrograma1.Size = new System.Drawing.Size(75, 23);
            this.btnPrograma1.TabIndex = 7;
            this.btnPrograma1.Text = "Programa 1";
            this.btnPrograma1.UseVisualStyleBackColor = true;
            this.btnPrograma1.Click += new System.EventHandler(this.btnPrograma1_Click);
            // 
            // btnPrograma2
            // 
            this.btnPrograma2.Location = new System.Drawing.Point(323, 183);
            this.btnPrograma2.Name = "btnPrograma2";
            this.btnPrograma2.Size = new System.Drawing.Size(75, 23);
            this.btnPrograma2.TabIndex = 8;
            this.btnPrograma2.Text = "Programa 2";
            this.btnPrograma2.UseVisualStyleBackColor = true;
            this.btnPrograma2.Click += new System.EventHandler(this.btnPrograma2_Click);
            // 
            // lblCargarPrograma
            // 
            this.lblCargarPrograma.AutoSize = true;
            this.lblCargarPrograma.Location = new System.Drawing.Point(45, 188);
            this.lblCargarPrograma.Name = "lblCargarPrograma";
            this.lblCargarPrograma.Size = new System.Drawing.Size(148, 13);
            this.lblCargarPrograma.TabIndex = 9;
            this.lblCargarPrograma.Text = "Programas de ejemplo: Cargar";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(323, 357);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnPrograma3
            // 
            this.btnPrograma3.Location = new System.Drawing.Point(323, 213);
            this.btnPrograma3.Name = "btnPrograma3";
            this.btnPrograma3.Size = new System.Drawing.Size(75, 23);
            this.btnPrograma3.TabIndex = 11;
            this.btnPrograma3.Text = "N Euclidiana";
            this.btnPrograma3.UseVisualStyleBackColor = true;
            this.btnPrograma3.Click += new System.EventHandler(this.btnPrograma3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Sumatoria N";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnPrograma4_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(667, 390);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 13;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // FormInterprete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnPrograma3);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.lblCargarPrograma);
            this.Controls.Add(this.btnPrograma2);
            this.Controls.Add(this.btnPrograma1);
            this.Controls.Add(this.btnEvaluar);
            this.Controls.Add(this.dGridTablaLexemas);
            this.Controls.Add(this.btnValidarSintaxis);
            this.Controls.Add(this.btnReconocerElementos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxCodigoAAnalizar);
            this.Name = "FormInterprete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interprete";
            ((System.ComponentModel.ISupportInitialize)(this.dGridTablaLexemas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxCodigoAAnalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReconocerElementos;
        private System.Windows.Forms.Button btnValidarSintaxis;
        private System.Windows.Forms.DataGridView dGridTablaLexemas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button btnEvaluar;
        private System.Windows.Forms.Button btnPrograma1;
        private System.Windows.Forms.Button btnPrograma2;
        private System.Windows.Forms.Label lblCargarPrograma;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnPrograma3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInfo;
    }
}

