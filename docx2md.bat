echo "Converting Docx to Md file"
pandoc ReadMe_v02.docx -s -o README.md

:: 
copy *.md tko\*.md
