using System; 

class  MainClass{ 
  private static NCategoria ncategoria = new NCategoria();
  private static NProduto nproduto = new NProduto();

  public static void Main() {
    int op = 0;
    Console.WriteLine("---- Supermarket System-----");
    do {
      try{
        op = Menu();
        switch (op){
          case 1 : CategoriaListar(); break;
          case 2 : CategoriaInserir(); break;
          case 3 : ProdutoListar(); break;
          case 4 : ProdutoInserir(); break;
        }
      }
      catch (Exception erro){
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine("Obrigado! Volte sempre!");
  }
  public static int Menu(){
    Console.WriteLine();
    Console.WriteLine("__________________");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("1 - Categoria - Listar");
    Console.WriteLine("2 - Categoria - inserir");
    Console.WriteLine("3 - Produto - Listar");
    Console.WriteLine("4 - Produto - inserir");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void CategoriaListar(){
    Console.WriteLine("----Lista de Categorias----");
    Categoria[] cs = ncategoria.Listar();
    if (cs.Length == 0){
      Console.WriteLine("Nenhuma categoria cadastrada");
      return;
    }
    foreach (Categoria c in cs) Console.WriteLine(c);
    Console.WriteLine();

  }
  public static void CategoriaInserir(){
    Console.WriteLine("---- Inserção de Categorias ---");
    Console.Write("Informe um código para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instaciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // inserção da categoria
    ncategoria.Inserir(c);
  }
  public static void ProdutoListar(){
    Console.WriteLine("----Lista de Produtos----");
    Produto[] ps = nproduto.Listar();
    if (ps.Length == 0){
      Console.WriteLine("Nenhum produto cadastrado");
      return;
    }
    foreach (Produto p in ps) Console.WriteLine(p);
    Console.WriteLine();

  }
  public static void ProdutoInserir(){
    Console.WriteLine("---- Inserção de Produtos ---");
    Console.Write("Informe um código para o produto: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe o estoque do produto: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preco do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("informe o nº de uma das categorias: ");
    int idcategoria = int.Parse(Console.ReadLine());
    // Selecionar a categoria a partir do id
    Categoria c = ncategoria.Listar(idcategoria);
    // instanciar a classe de produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    //inserção do Produto
    nproduto.Inserir(p);
  }
}