import sys, csv, cv2
import numpy as np

# PARAMS
params = sys.argv[1].split(" ")
image_array = params[0]
width = int(params[1])
height = int(params[2])
sendViaFTP = eval(params[3])
wavelength = params[4]
flipX = eval(params[5])
flipY = eval(params[6])



csv.field_size_limit(4 * width * height)

# read image from csv
f = open(image_array, "r")
reader = csv.reader(f)
strImg = ""
for row in reader:
    strImg += row[0]
f.close()

img = np.reshape(np.array(strImg.split(" "), dtype=np.uint8), (-1, height))
img = np.rot90(img)

if flipX:
    img = np.flip(img,1)
if flipY:
    img = np.flip(img,0)

outFilename = image_array.replace(".csv", ".bmp").replace(".stf",".bmp")
cv2.imwrite(outFilename, img)
print(outFilename)
print("Image has been saved")
