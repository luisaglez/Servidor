using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace Servicio1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGuardar" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGuardar
    {
        [OperationContract]
        void guardar (int a, string b, string c, string d, int e, string f);
        [OperationContract]
        string [] buscar (int cla);
        [OperationContract]
        List<string> mostrar();
        [OperationContract]
        string obtener(int con);
        [OperationContract]
        string num(string n);
        [OperationContract]
        string toText(double value);

    }

}
