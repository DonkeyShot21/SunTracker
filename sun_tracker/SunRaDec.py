import ephem, math, datetime
from astropy.coordinates import Angle

home = ephem.Observer()
home.date = str(datetime.datetime.now())[:-7]
home.lat = '40.444091'
home.lon = '-3.952610'

sun = ephem.Sun()
sun.compute(home)

ra = Angle(str(sun.ra) + " d").degree
dec = Angle(str(sun.dec) + " d").degree

print(ra, dec)

# esac 40.444091, -3.952610
