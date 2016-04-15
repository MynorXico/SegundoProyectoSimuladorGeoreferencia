using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace Proyecto2_SimuladorCiudades
{
    static class ManejoDatos
    {
        static TextBox tbDirection;
        static ListBox lbObjetos;
        static ProgressBar pbLoading;

        #region ArrayLists con cada tipo de objeto
        public static ArrayList registroCarro = new ArrayList();
        public static ArrayList registroRestaurantes = new ArrayList();
        public static ArrayList registroHospitales = new ArrayList();
        public static ArrayList registroGasolineras = new ArrayList();
        public static ArrayList registroPolicias = new ArrayList();
        public static ArrayList registroBomberos = new ArrayList();
        public static OpenFileDialog abrirarchivo = new OpenFileDialog();


        public static ArrayList[] arrObjetos = new ArrayList[6];        
        #endregion


        public static void lecturadearchivo(TextBox tb, ListBox lb, ProgressBar pb, ArrayList[] arrayList)
        {
            pbLoading = pb;
            pbLoading.Maximum = 6;
            pbLoading.Step = 1;
            abrirarchivo.Filter = "Text Files|*.txt";//Solo los archivos de texto podran ser manejados por la carga de datos

            tbDirection = tb;
            lbObjetos = lb;
            arrObjetos = arrayList;
            int[] intcontador_error = new int[6];//Arreglo que contendra contadores para menejar el error descrito al final de cada sección de cada objeto
            int[] intContadorObjetos = new int[6];//Arreglo que contendra los contadore spara cada objeto que se va a crear...
            try
            {
                if (abrirarchivo.ShowDialog() == DialogResult.OK)//El archivo se lee de forma correcta
                {
                    if (Path.GetExtension(abrirarchivo.FileName) != ".txt")//En caso de que se ingrese un archivo que no sea de texto, el programa lanzara la excepción y manejara el error
                        throw new InvalidOperationException();

                    tbDirection.Text = abrirarchivo.FileName;//Este textbox recibe la dirección del archivo de texto que se lee
                    StreamReader lecturadearchivo = new StreamReader(abrirarchivo.FileName);
                    string lineas = lecturadearchivo.ReadLine();//Esta variable leera cada linea del archivo de texto seleccionado
                    string[] arrdatosCarro = new string[5];//Arreglo que guardara la información de cada linea de carros
                    string[] arrdatosRestaurantes = new string[4];//Arreglo que guardara la información de cada linea de restaurantes
                    string[] arrdatosHospitales = new string[4];//Arreglo que guardara la informacion de cada linea de hospitales
                    string[] arrdatosGasolineras = new string[4];//Arreglo que guardara la información de cada linea de gasolineras
                    string[] arrdatosPolicias = new string[4];//Arreglo que guardara la información de cada linea de policias
                    string[] arrdatosBomberos = new string[4];//Arreglo que guardara la información de cada linea de bomberos
                    while (lineas != null)//Mientra haya lineas por leer
                    {
                        do
                        {
                            lineas = lecturadearchivo.ReadLine();//El programa leera lineas vacias hasta que encuentre una con letras
                        } while (lineas == "" || lineas == null);
                        switch (lineas)
                        {
                            case "vehiculos:":
                                #region//Lectura de los objetos carro
                                try
                                {
                                    while (lineas != "fin_vehiculos" && intContadorObjetos[0] <= 99)
                                    {
                                        if (intcontador_error[0] == 0)//Esto corrige el error de que los arreglos traten de meter la sentencia fin_vehiculo como un miembro de un objeto carro
                                        {
                                            lineas = lecturadearchivo.ReadLine();
                                        }
                                        arrdatosCarro = lineas.Split('|');//Este arreglo se llena con cada palabra dividida por un "|"
                                        string placa = arrdatosCarro[0].Trim();//se define el valor de la placa, 
                                        int calle = int.Parse(arrdatosCarro[1].Trim());//Se define el valor de la calle
                                        int avenida = int.Parse(arrdatosCarro[2].Trim());//se define el valor de la avenida
                                        int excepcion = int.Parse(arrdatosCarro[3].Trim());//Se define el valor que indica si el objeto esta sobre la calle o sobre una avenida
                                        string marca = arrdatosCarro[4].Trim();//se defin el valor de la placa
                                        string calleoAvenida = "";//Indicara si el objeto se encuentra sobre una calle o una avenida dependiendo del valor que este tomo

                                        if (excepcion == 1)//En caso de que el valor del parametro excepción sea 1, el objeto se encontrar sobre la avenida en donde figura su ubicación
                                        {
                                            calleoAvenida = "Avenida";
                                        }
                                        else if (excepcion == 2)//En caso de que el valor de excepción sea 2, el carro se enontrar sobre una calle, en la que figura su posición
                                        {
                                            calleoAvenida = "Calle";
                                        }
                                        Vehiculo carro = new Vehiculo(placa, calle, avenida, excepcion, marca);
                                        //Cada vez que entre en este ciclo, se instanciaran las variables pero tomaran diferentes valores

                                        lbObjetos.Items.Add(string.Format("Carro {0}\tPlacas: {1}\tCalle: {2}\tAvenida: {3}\tEl carro se encuentra sobre la {4}\tMarca: {5}", (intContadorObjetos[0] + 1), carro.strPlaca, carro.intCalle, carro.intAvenida, calleoAvenida, carro.strMarca));
                                        //Se añadira un la información de cada objeto a un listbox
                                        lineas = lecturadearchivo.ReadLine();//Se lee una linea
                                        intcontador_error[0]++;//Este contador es utilizado para que solo se pueda entrar al ciclo una vez y el programa no intente tomar la linea de fin_vehiculo como parte del arreglo
                                        intContadorObjetos[0]++;//El contador de carros aumenta en 1, su unico fin es identificar a cada objeto que se crea, ya que por defecto tendran el mismo nombre
                                        if (intContadorObjetos[0] > 99)//En caso de que se creen una cantidad excesiva de objetos de este tipo ocurrira una excepción
                                        {
                                            throw new InvalidOperationException();
                                        }
                                        registroCarro.Add(carro);//En cada iteración exitosa se agrega el objeto a un arraylist para ser usados en la generación del mapa
                                    } arrObjetos[0] = (registroCarro);
                                }
                                catch (InvalidOperationException)
                                {
                                    MessageBox.Show("La cantidad de objetos es invalida");
                                }
                                #endregion
                                pbLoading.PerformStep();
                                break;
                            case "restaurantes:":
                                #region//Lectura de datos de Restaurantes
                                while (lineas != "fin_restaurantes" && intContadorObjetos[1] <= 49)//Solo se podran crear un máximo de 50 objetos carros
                                {
                                    try
                                    {
                                        if (intcontador_error[1] == 0)
                                        {
                                            lineas = lecturadearchivo.ReadLine();
                                        }
                                        arrdatosRestaurantes = lineas.Split('|');
                                        string strNombreRestaurante = arrdatosRestaurantes[0].Trim();
                                        int intCalleRestaurante = int.Parse(arrdatosRestaurantes[1].Trim());
                                        int intAvenida = int.Parse(arrdatosRestaurantes[2].Trim());
                                        int inttipoRestaurante = int.Parse(arrdatosRestaurantes[3].Trim());

                                        address adDireccion = new address();
                                        adDireccion.intAvenida = intAvenida;
                                        adDireccion.intCalle = intCalleRestaurante;

                                        string tipo = "";//variable que guardara el tipo de comida que tendra cada restaurante
                                        if (inttipoRestaurante == 1)//se evalua que el tipo de restaurantes sea de los unicos permitidos
                                        {
                                            tipo = "Comida Rápida";
                                        }
                                        else if (inttipoRestaurante == 2)
                                        {
                                            tipo = "Pizzería";
                                        }
                                        else if (inttipoRestaurante == 3)
                                        {
                                            tipo = "Comida Gourmet";
                                        }
                                        else if (inttipoRestaurante != 1 && inttipoRestaurante != 2 && inttipoRestaurante != 3)
                                        {//En caso de que el archivo de texto tenga un restaurante que no tenga un tipo de dato con válido, resopecto al tipo de comida que vendera se mostrara el error y se le asignara un tipo de restaurante

                                            MessageBox.Show("El  restaurente (" + (strNombreRestaurante) + ") no posee un tipo de comida válido\nSe le asigno como tipo de comida rapida");
                                            tipo = "Comida Rapida";
                                        }
                                        Buildings.Restaurante restaurante = new Buildings.Restaurante(strNombreRestaurante, adDireccion, inttipoRestaurante);//Cada vez que entra al ciclo instancia un objeto restaurante con direrentes valores
                                        lbObjetos.Items.Add("Restaurante No. " + (intContadorObjetos[1] + 1) + "\tNombre del Restaurante: " +//Se agrega al listbox la informacion de cada objeto carro
                                            restaurante.strNombre + "\tNo.de Calle " + restaurante.adDireccion.intCalle + "\tNo.de Avenida " + restaurante.adDireccion.intAvenida +
                                            "\tTipo de Restaurante :" + tipo);
                                        lineas = lecturadearchivo.ReadLine();
                                        intContadorObjetos[1]++;//Se aumente en 1 el contador de objetos Resaurantes, que esta contenido en la segunda posición del arreglo de contadore de objetos
                                        intcontador_error[1]++;//Se aumenta en el cintador utilizado para manejar el error en el que el porgrama intenta asignar la linea de fin_vehiculo al arreglo de datos de vehiculo+
                                        registroRestaurantes.Add(restaurante);//Se añade un restaurante al registro de restaurantes para ser usados en el mapa

                                    }
                                    catch (InvalidOperationException)
                                    {
                                        MessageBox.Show("La cantidad de Restaurantes en el archivo de texto es inválida");
                                    }
                                }
                                arrObjetos[1] = (registroRestaurantes);
                                #endregion
                                pbLoading.PerformStep();
                                break;
                            case "hospitales:":
                                #region//Inicio de lectura de los objetos hospitales
                                try
                                {
                                    while (lineas != "fin_hospitales" && intContadorObjetos[2] <= 19)
                                    {
                                        if (intcontador_error[2] == 0)
                                        {
                                            lineas = lecturadearchivo.ReadLine();
                                        }
                                        arrdatosHospitales = lineas.Split('|');
                                        string strNombreHospital = arrdatosHospitales[0].Trim();
                                        int intcalleHospital = int.Parse(arrdatosHospitales[1].Trim());
                                        int intavenidaHospital = int.Parse(arrdatosHospitales[2].Trim());
                                        int intTipoHospital = int.Parse(arrdatosHospitales[3].Trim());
                                        bool esPublico;
                                        address adDireccion = new address();
                                        adDireccion.intCalle = intcalleHospital;
                                        adDireccion.intAvenida = intavenidaHospital;
                                        if (intTipoHospital == 1)
                                        {//En caso de que el archivo de texto asigne como 1 a la posicion 4 de del arreglo de datos de hospital, el hospital en cuestion sera privado
                                            esPublico = false;
                                        }
                                        else
                                        {
                                            esPublico = true;
                                        }
                                        Buildings.Hospital hospital = new Buildings.Hospital(strNombreHospital, adDireccion, esPublico);
                                        lbObjetos.Items.Add("Hospital No." + (intContadorObjetos[2] + 1) + "\tNombre del Hospital: " + hospital.strNombre +
                                            "\tNo. de Calle: " + hospital.adDireccion.intCalle + "\tNo. de avenida: " + hospital.adDireccion.intAvenida + "\tTipo de Hospital: " + hospital.strTipo);
                                        intContadorObjetos[2]++;//El contador de hospitales ubicado en la tercera posición del arreglo de contadores aumentara en 1
                                        intcontador_error[2]++;//El contador de error que manejara el porblema de la linea extra aumentara en 1
                                        registroHospitales.Add(hospital);
                                        lineas = lecturadearchivo.ReadLine();//Se lee el archivo de texto
                                    }
                                }
                                catch (FormatException)
                                {
                                    MessageBox.Show("Esta mal configurado la carga de datos");
                                }
                                arrObjetos[2] = (registroHospitales);
                                #endregion
                                pbLoading.PerformStep();
                                break;
                            case "gasolineras:":
                                #region//Inicio de lectura de las gasolineras
                                try
                                {
                                    while (lineas != "fin_gasolineras" && intContadorObjetos[3] <= 49)//Solo se permitira el ingreso de 50 gasolineras
                                    {
                                        if (intcontador_error[3] == 0)
                                        {
                                            lineas = lecturadearchivo.ReadLine();
                                        }
                                        arrdatosGasolineras = lineas.Split('|');
                                        string strNombre = arrdatosGasolineras[0].Trim();
                                        int intCalle = int.Parse(arrdatosGasolineras[1].Trim());
                                        int intAvenida = int.Parse(arrdatosGasolineras[2].Trim());
                                        double dblprecio = double.Parse(arrdatosGasolineras[3].Trim());
                                        address adDireccion = new address();
                                        adDireccion.intCalle = intCalle;
                                        adDireccion.intAvenida = intAvenida;

                                        Buildings.Gasolinera gasolinera = new Buildings.Gasolinera(strNombre, adDireccion, dblprecio);
                                        lbObjetos.Items.Add("Gasolinera No.: " + (intContadorObjetos[3] + 1) + "\tNombre de Gasolinera: " + gasolinera.strNombre +
                                            "\tNo. de Calle: " + gasolinera.adDireccion.intCalle + "\tNo. de Avenia: " + gasolinera.adDireccion.intAvenida + "\tPrecio de la gasolina: " +
                                            gasolinera.dblPrecio + ".Q");
                                        registroGasolineras.Add(gasolinera);//Se agrega cada gasolinera creada a este arraylist
                                        intcontador_error[3]++;
                                        intContadorObjetos[3]++;
                                        lineas = lecturadearchivo.ReadLine();
                                    }
                                }
                                catch
                                {
                                }
                                arrObjetos[3] = (registroGasolineras);
                                #endregion
                                pbLoading.PerformStep();
                                break;
                            case "policias:":
                                #region //Inicio de lectura de los policías
                                try
                                {
                                    while (lineas != "fin_policias" && intContadorObjetos[4] <= 19)//Solo se permitiran un maximo de 20 oficiales de policia
                                    {
                                        if (intcontador_error[4] == 0)
                                        {
                                            lineas = lecturadearchivo.ReadLine();
                                        }
                                        arrdatosPolicias = lineas.Split('|');
                                        string strNombrePolicia = arrdatosPolicias[0].Trim();
                                        int intcallePolicia = int.Parse(arrdatosPolicias[1].Trim());
                                        int intAvenidaPolicia = int.Parse(arrdatosPolicias[2].Trim());
                                        int intUbicacionPolicia = int.Parse(arrdatosPolicias[3].Trim());

                                        Vehicles.Policia patrulla = new Vehicles.Policia(strNombrePolicia, intcallePolicia, intAvenidaPolicia, intUbicacionPolicia);
                                        lbObjetos.Items.Add("Policía No.: " + (intContadorObjetos[4] + 1) + "\tNombre de Policía: " + patrulla.strNombre +
                                            "\tNo. de Calle: " + patrulla.intCalle + "\tNo. de Avenia: " + patrulla.intAvenida + "\tEsta sobre la: " +
                                            patrulla.strCalleAvenida);
                                        registroPolicias.Add(patrulla);//Se agrega cada gasolinera creada a este arraylist
                                        intcontador_error[4]++;
                                        intContadorObjetos[4]++;
                                        lineas = lecturadearchivo.ReadLine();
                                    }
                                }
                                catch
                                {

                                }
                                pbLoading.PerformStep();
                                arrObjetos[4] = (registroPolicias);
                                break;
                            #endregion
                            case "bomberos:":
                                #region //Inicio de lectura de los policías
                                try
                                {
                                    while (lineas != "fin_bomberos" && intContadorObjetos[5] <= 19)//Solo se permitiran un maximo de 20 bomberos
                                    {
                                        if (intcontador_error[5] == 0)
                                        {
                                            lineas = lecturadearchivo.ReadLine();
                                        }
                                        arrdatosBomberos = lineas.Split('|');
                                        string strNombreBombero = arrdatosBomberos[0].Trim();
                                        int intCalleBombero = int.Parse(arrdatosBomberos[1].Trim());
                                        int intAvenidaBombero = int.Parse(arrdatosBomberos[2].Trim());
                                        int intUbicacionBombero = int.Parse(arrdatosBomberos[3].Trim());

                                        Vehicles.Ambulancia ambulancia = new Vehicles.Ambulancia(strNombreBombero, intCalleBombero, intAvenidaBombero, intUbicacionBombero);
                                        lbObjetos.Items.Add("Ambulancia No.: " + (intContadorObjetos[5] + 1) + "\tNombre de Ambulancia: " + ambulancia.strNombre +
                                            "\tNo. de Calle: " + ambulancia.intCalle + "\tNo. de Avenia: " + ambulancia.intAvenida + "\tEsta sobre la: " +
                                            ambulancia.strCalleAvenida);
                                        registroBomberos.Add(ambulancia);//Se agrega cada gasolinera creada a este arraylist
                                        intcontador_error[5]++;
                                        intContadorObjetos[5]++;
                                        lineas = lecturadearchivo.ReadLine();
                                    }

                                }
                                catch
                                {

                                }
                                arrObjetos[5]=(registroBomberos);
                                pbLoading.PerformStep();
                                break;
                                #endregion
                        }
                        lineas = lecturadearchivo.ReadLine();
                    }
                    lecturadearchivo.Close();//El archivo se cerrara cuando ya ni hayan lineas por leer
                }
                
            }
            catch (InvalidOperationException)
            {//En caso de hacer una operacióin no valida...
                //En caso de que el usuario trate de ingresar a un archivo inválido el programa lanzara el siguiente mensaje
                MessageBox.Show("El archivo no es válido, el programa solo leera archivos con el tipo de extensión (.txt)");
                //La textbox que contiene la dirección del archivo de textoe se limpiara...
                tbDirection.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("El archivo esta mal configurado");
            }
            arrayList = arrObjetos;
        }



    }
}
