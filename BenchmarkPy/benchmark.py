# -*- coding: utf-8 -*-

import hashlib
import time
import datetime

m = hashlib.sha256()
def Average(lst):
    return sum(lst) / len(lst)

class NombreNumero:
    def ToHex(nomb:str):
        m.update(nomb.encode())
        hx = m.hexdigest()
        return hx 
    def __init__(self, nomb: str, num: int):
        
        result = hashlib.sha256(nomb.encode())
        self.nombre = result.hexdigest()
        self.numero = num

unaLista = []
listAvg =[]
for i in range(5):
    start = datetime.datetime.now()
    for j in range(1000000):
        stra = str(j)
        unaLista.append(NombreNumero(stra,i))
    unaLista.clear()
    end = datetime.datetime.now()
    delta = end - start
    milliseconds = int(delta.total_seconds()*1000)
    listAvg.append(milliseconds)
    print(f"Elapsed: {milliseconds}")

print(Average(listAvg))