using System;
using System.Collections.Generic;

class Venda {
 // Atributos do item de VendaItem
 private int id;
 private DateTime data;
 private bool carrinho;
 // Associação entre Venda e cliente
 private Cliente cliente;
 // Associação entre venda e VendaItem
 private List<VendaItem> itens = new List<VendaItem>();

 public Venda(DateTime data, Cliente cliente) {
  this.data = data;
  this.carrinho = true;
  this.cliente = cliente;
  }
  public void SetId(int id) {
   this.id = id;
  }
  public void SetData(DateTime data){
    this.data = data;
  }
  public void SetCarrinho(bool carrinho){
    this.carrinho = carrinho;
  }
  public void SetCliente(Cliente cliente){
    this.cliente = cliente;
  }

  public int GetId() {
   return id;
  }
  public DateTime GetData(){
    return data;
  }
  public bool GetCarrinho(){
    return carrinho;
  }
  public Cliente GetCliente(){
    return cliente;
  }
  public override string ToString(){
    if (carrinho){
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Cliente " + cliente.Nome + " - carrinho";
    }
    else{
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + "- Cliente: " + cliente.Nome;  
    }
  }

  private VendaItem ItemListar(Produto p){
   // Verificar se o produto p já está na lista de itens
    foreach(VendaItem vi in itens){
     if (vi.GetProduto() == p) return vi;
    }
    return null;
  }

  public List<VendaItem> ItemListar(){
    // retornar a lista de itens
    return itens;
  }

  public void ItemInserir(int qtd, Produto p){
    // Verificar se o produto p já está na lista de itens
    VendaItem item = ItemListar(p);
    if (item == null){
      item = new VendaItem(qtd, p);
      itens.Add(item);
    }
    else {
      item.SetQtd(item.GetQtd() + qtd);
    }
  }
  public void ItemExcluir(){
    // exclui todos os itens da lista
    itens.Clear();
  }
}