using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Interfaces;
using WebAPI.Model;

namespace WebAPI.Repository;

public class RepositoryProduto : RepositoryGeneric<Produto>, IProduto
{
}