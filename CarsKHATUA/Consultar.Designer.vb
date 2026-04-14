<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Consultar
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Consultar))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdicionarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CadastroDeProdutoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstoqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.txt_buscar = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmd_campo = New System.Windows.Forms.ToolStripComboBox()
        Me.dgv_dados = New System.Windows.Forms.DataGridView()
        Me.id_produto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.desc_produto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.categoria_produto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marca_produto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qnt_dis_prod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.preco_venda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbl_margem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btn_excluir = New System.Windows.Forms.DataGridViewImageColumn()
        Me.btn_editar = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.VendasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgv_dados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdicionarToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1037, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdicionarToolStripMenuItem
        '
        Me.AdicionarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CadastroDeProdutoToolStripMenuItem, Me.EstoqueToolStripMenuItem, Me.VendasToolStripMenuItem})
        Me.AdicionarToolStripMenuItem.Image = CType(resources.GetObject("AdicionarToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AdicionarToolStripMenuItem.Name = "AdicionarToolStripMenuItem"
        Me.AdicionarToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.AdicionarToolStripMenuItem.Text = "Menu"
        '
        'CadastroDeProdutoToolStripMenuItem
        '
        Me.CadastroDeProdutoToolStripMenuItem.Image = CType(resources.GetObject("CadastroDeProdutoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CadastroDeProdutoToolStripMenuItem.Name = "CadastroDeProdutoToolStripMenuItem"
        Me.CadastroDeProdutoToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.CadastroDeProdutoToolStripMenuItem.Text = "Cadastro de produto"
        '
        'EstoqueToolStripMenuItem
        '
        Me.EstoqueToolStripMenuItem.Image = CType(resources.GetObject("EstoqueToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EstoqueToolStripMenuItem.Name = "EstoqueToolStripMenuItem"
        Me.EstoqueToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.EstoqueToolStripMenuItem.Text = "Estoque de Produtos"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.txt_buscar, Me.ToolStripLabel2, Me.cmd_campo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1037, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(124, 22)
        Me.ToolStripLabel1.Text = "selecione o parâmetro"
        '
        'txt_buscar
        '
        Me.txt_buscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.txt_buscar.Name = "txt_buscar"
        Me.txt_buscar.Size = New System.Drawing.Size(100, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(106, 22)
        Me.ToolStripLabel2.Text = "selecione o campo"
        '
        'cmd_campo
        '
        Me.cmd_campo.Name = "cmd_campo"
        Me.cmd_campo.Size = New System.Drawing.Size(121, 25)
        '
        'dgv_dados
        '
        Me.dgv_dados.AllowUserToAddRows = False
        Me.dgv_dados.AllowUserToDeleteRows = False
        Me.dgv_dados.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgv_dados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_dados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id_produto, Me.desc_produto, Me.categoria_produto, Me.marca_produto, Me.qnt_dis_prod, Me.preco_venda, Me.lbl_margem, Me.btn_excluir, Me.btn_editar})
        Me.dgv_dados.GridColor = System.Drawing.Color.DarkSlateGray
        Me.dgv_dados.Location = New System.Drawing.Point(58, 128)
        Me.dgv_dados.Name = "dgv_dados"
        Me.dgv_dados.Size = New System.Drawing.Size(943, 303)
        Me.dgv_dados.TabIndex = 1
        '
        'id_produto
        '
        Me.id_produto.HeaderText = "ID"
        Me.id_produto.Name = "id_produto"
        '
        'desc_produto
        '
        Me.desc_produto.HeaderText = "Descrição Produto"
        Me.desc_produto.Name = "desc_produto"
        '
        'categoria_produto
        '
        Me.categoria_produto.HeaderText = "Categoria"
        Me.categoria_produto.Name = "categoria_produto"
        '
        'marca_produto
        '
        Me.marca_produto.HeaderText = "Marca/Fabricante "
        Me.marca_produto.Name = "marca_produto"
        '
        'qnt_dis_prod
        '
        Me.qnt_dis_prod.HeaderText = "Quantidade Disponível "
        Me.qnt_dis_prod.Name = "qnt_dis_prod"
        '
        'preco_venda
        '
        Me.preco_venda.HeaderText = "Preço de venda"
        Me.preco_venda.Name = "preco_venda"
        '
        'lbl_margem
        '
        Me.lbl_margem.HeaderText = "Margem de Lucro"
        Me.lbl_margem.Name = "lbl_margem"
        '
        'btn_excluir
        '
        Me.btn_excluir.HeaderText = "Deletar"
        Me.btn_excluir.Image = CType(resources.GetObject("btn_excluir.Image"), System.Drawing.Image)
        Me.btn_excluir.Name = "btn_excluir"
        Me.btn_excluir.ReadOnly = True
        Me.btn_excluir.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_excluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'btn_editar
        '
        Me.btn_editar.HeaderText = "Editar"
        Me.btn_editar.Image = CType(resources.GetObject("btn_editar.Image"), System.Drawing.Image)
        Me.btn_editar.Name = "btn_editar"
        Me.btn_editar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.btn_editar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(350, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(264, 39)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Consulta geral "
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(620, 65)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(65, 57)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'VendasToolStripMenuItem
        '
        Me.VendasToolStripMenuItem.Image = CType(resources.GetObject("VendasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.VendasToolStripMenuItem.Name = "VendasToolStripMenuItem"
        Me.VendasToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.VendasToolStripMenuItem.Text = "Vendas"
        '
        'Consultar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(1037, 443)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dgv_dados)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Consultar"
        Me.Text = "Consultar"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgv_dados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AdicionarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CadastroDeProdutoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents txt_buscar As ToolStripTextBox
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents cmd_campo As ToolStripComboBox
    Friend WithEvents dgv_dados As DataGridView
    Friend WithEvents id_produto As DataGridViewTextBoxColumn
    Friend WithEvents desc_produto As DataGridViewTextBoxColumn
    Friend WithEvents categoria_produto As DataGridViewTextBoxColumn
    Friend WithEvents marca_produto As DataGridViewTextBoxColumn
    Friend WithEvents qnt_dis_prod As DataGridViewTextBoxColumn
    Friend WithEvents preco_venda As DataGridViewTextBoxColumn
    Friend WithEvents lbl_margem As DataGridViewTextBoxColumn
    Friend WithEvents btn_excluir As DataGridViewImageColumn
    Friend WithEvents btn_editar As DataGridViewImageColumn
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents EstoqueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VendasToolStripMenuItem As ToolStripMenuItem
End Class
