#Instrucciones para contribuir #


##Renuncia##
Este proyecto es un proyecto comunitario no para uso comercial. El emulador en sí es una prueba del concepto de nuestra idea de probar cualquier cosa que no sea posible en los servidores originales. El resultado es aprender y programar juntos para probar el estudio.

##Legal##

Este Sitio Web y el Proyecto no están de ninguna manera afiliados, autorizados, mantenidos, patrocinados o endosados ​​por Gameforge o cualquiera de sus filiales o subsidiarias. Este es un servidor independiente y no oficial para uso educativo SOLAMENTE. El uso del Proyecto podría estar en contra de los TOS.

#¡Atención!#
Este software de emulación no es de código abierto para alojar servidores privados. Es de código abierto para trabajar juntos en la comunidad.

No proporcionamos ningún archivo de cliente modificado. Los algoritmos se basan en nuestra lógica.

## Antes de crear un problema, puede ponerse en contacto con nosotros en Discord.
Https://discordapp.com/invite/qdPMDv5

## Información Especial para Usuarios de Hamachii y VPN ##
Si desea utilizar los servidores que necesita para modificar el Program.cs de OpenNos.Login y OpenNos.World y reconstruir el código.
- Cambiar "127.0.0.1" a "HamachiIp" (Ej. "12.34.567.89")
- No olvide modificar el app.config del servidor de inicio de sesión en el redireccionamiento correcto (<server Name = "S1-OpenNos" WorldPort = "1337" WorldIp = "25.71.84.227" channelAmount = "1" />)

###Contribution is only possible with Visual Studio 2015 (Community or other editions), Microsoft SQL Server 2016, [StyleCop extension](https://stylecop.codeplex.com/) and [ResX Resource Manager](https://resxresourcemanager.codeplex.com/)###
#NOTA ANTES DE INSTALAR #
- Error escuchar punto: - Esto es error de WCF instalarlo o ejecutar opennos en Visual Studio
- żCuáles son los comandos? : $ Help
- ¿Podemos tener su paquete.txt: No! Analizarlos usted mismo sólo olfatearlos!
- ¿Podemos tener otros archivos para analizador? : Sí, simplemente extrayendo de su cliente: nslangdata.dat, nsgtddata.dat, nstcdata.dat
- En el inicio de sesión no sucede nada: verificar que puede conectarse con telnet en el puerto correcto "telnet 127.0.0.1 80". Si es que no está en el puerto correcto de su cliente. Si no, ha instalado algo incorrecto, compruebe si ha desactivado cualquier programa que funcione en el puerto 80 (por ejemplo, skype).
- Si todavía no se ha solucionado el problema, busque dentro de nuestro archivo de solución de problemas.
- No se reconoce la contraseña: compruebe que su contraseña es hash en sha512 y que su lanzador (hecho por usted mismo) se hace con el nostaleX.dat más reciente
- Los monstruos no se mueven: analizar los paquetes mv.
- La receta no funciona: analiza cada receta haciendo clic en ellos para los paquetes.
- El emulador se cierra después de unos segundos: Compruebe si el puerto 80 ya no está en uso (por ejemplo, skype ...)

## 1 Instale SSDT para VS ##
Http://go.microsoft.com/fwlink/?LinkID=393520&clcid=0x409

## 2 Instale el instalador de MySQL (solo navegue a través del instalador) ##
Http://dev.mysql.com/downloads/windows/installer/

Paquetes del instalador:
- Instalación personalizada
  - Servidor MySQL x64 (Servidor de base de datos)
  - MySQL Workbench x64 (edición de datos)
  - MySQL Notifier x86 (Estado de Icono de la Barra de Tareas)
  - MySQL para Visual Studio x86
  - Conector / NET x86 (de acuerdo a nuestra prueba theres un problema con la versión 6.9.9 por favor, utilice [6.9.8 en su lugar] (https://downloads.mysql.com/archives/get/file/mysql-connector-net-6.9 .8msi))
  
- Puerto: 3306
- Usuario: test
- Contraseña: test

## 3 Instalar MYSQL para Visual Studio ##

## 4 Utilice NuGet Package Manager para actualizar la base de datos ##

- Ir a Herramientas -> NuGet Package Manager -> Consola del gestor de paquetes
- Elija Proyecto OpenNos.DAL.EF.MySQL
- Escriba 'update-database' y actualice la base de datos
