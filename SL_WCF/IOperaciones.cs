﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOperaciones" in both code and config file together.
    [ServiceContract]
    public interface IOperaciones
    {
        [OperationContract]
        int sumar(int numero1, int numero2);

        [OperationContract]
        int restar(int numero1, int numero2);

        [OperationContract]
        int multiplicar(int numero1, int numero2);

        [OperationContract]
        int dividir(int numero1, int numero2);

        [OperationContract]
        string saludar(string nombre);
    }
}