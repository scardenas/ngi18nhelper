# ngi18nhelper
Permite aplicar traducciones en ficheros RESX a un fichero XLIFF

<br>

<code>
Uso: ngi18nhelper "XLIFF sin traducir generado en Angular" "fichero RESX" "fichero XLIFF destino"
</code>

<code>
docker run -e ORIGIN=/app/files/messages.xlf -e RESX=/app/files/Textos.en.resx -e TARGET=/app/files/messages.en.xlf -v /d/proyectos:/app/files  ngi18nhelper:dev
</code>
