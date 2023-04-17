from io import BytesIO
import PyPDF2
from tkinter import *


packet = BytesIO()
can = canvas.Canvas(packet)
can.drawString(10, 10, text)
can.save()
packet.seek(0)
new_pdf = PdfFileReader(packet)

# Read existing PDF
existing_pdf = PdfFileReader(open("output.pdf", "rb"))

# Write the new PDF to a file
output = PdfFileWriter()
output.addPage(new_pdf.getPage(0))

for i in range(existing_pdf.getNumPages()):
    output.addPage(existing_pdf.getPage(i))

with open("output.pdf", "wb") as f:
    output.write(f)