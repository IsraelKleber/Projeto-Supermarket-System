using System; 
 class Produto{
    private int id;
    private string descricao;
    private int qtd;
    private double preco;
    private Categoria categoria;

    public Produto(int id, string descricao, int qtd, double preco, Categoria categoria){
      this.id = id;
      this.descricao = descricao;
      this.qtd = qtd > 0 ? qtd : 0;
      this.preco = preco > 0 ? preco : 0;
      this.categoria = categoria;
    }

    public void SetId(int id){
      this.id = id;
    }
    public void SetDescricao(string descricao){
      this.descricao = descricao;
    }
    public void SetQtd(int qtd){
      this.qtd = qtd > 0 ? qtd : 0;
    }
    public void SetPreco(double preco){
      this.preco = preco > 0 ? preco : 0;
    }
    public void SetCategoria(Categoria categoria){
      this.categoria = categoria;
    }
    public int GetId(){
      return id;
    }
    public string GetDescricao(){
      return descricao;
    }
    public int GetQtd(){
      return qtd;
    }
    public double GetPreco(){
      return preco;
    }
    public Categoria GetCategoria(){
      return categoria;
    }

    public override string ToString(){
      if (categoria == null)
        return id + " - " + descricao + " - estoque: " + qtd + " - preço: R$" + preco.ToString("0.00");
      else
        return id + " - " + descricao + " - estoque: " + qtd + " - preço: R$" + preco.ToString("0.00") + " - " + categoria.GetDescricao();
    }
  }