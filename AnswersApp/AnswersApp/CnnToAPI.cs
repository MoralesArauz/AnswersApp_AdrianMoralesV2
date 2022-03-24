using System;
using System.Collections.Generic;
using System.Text;

namespace AnswersApp
{
    public static class CnnToAPI
    {
        // En esta clase estática vamos a almacenar la info de configuración
        // de consumo del API 
        // En pruebas normalmente se usa una ruta distinta en Producción

        public static string ProductionRoute = "http://192.168.100.142:45455/api/";
        public static string TestingRoute = "http://192.168.100.142:45455/api/";

        // TODO: Agregar funcionalidad para JWT

        // El apu key aca es util ya que el usuario antes de registrarse podría usarlo
        // y ya una vez registrado puede usar el JWT

        public static string ApiKeyName = "ApiKey";
        public static string ApiKeyValue = "WbIveOrmvSqfxlsSGPOhf0FY1xyzSDW9";
    }
}
