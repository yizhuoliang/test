# setup.py

from setuptools import setup
from Cython.Build import cythonize

setup(
    name='Add Two Numbers',
    ext_modules=cythonize("api.py"),
)