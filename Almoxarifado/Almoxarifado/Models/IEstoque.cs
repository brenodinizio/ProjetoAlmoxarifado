using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Almoxarifado.Models
{
    internal interface IEstoque
    {
        bool verificarEstoque(PRODUTO produto, int qtd);
    }
}