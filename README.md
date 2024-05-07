<p align="center">

![](/Images/figure_01-no-labels.png?raw=true)

</p>

# Stick&Slip

This is a repository for the prototype Stick&Slip device created by Alex Mazursky, Jacob Serfaty, and Pedro Lopes at the University of Chicago's [Human Computer Integration Lab](https://lab.plopes.org/). Stick&Slip is a wearable approach to alter the friction of everyday objects using liquid coatings on the fingerpad!


## Repository Structure

* `Arduino` contains code for the microcontroller (ESP32).
* `PCB` contains the KICAD files for our custom PCB.
* `3D-prints` contains models for the wearable droplet generator and bracelet (.stl files). These can be printed with most SLA printers.


## Hardware

<p align="center">

![](/Images/device-2.png?raw=true)

</p>

To reproduce our experience, we include the KiCad files to manufacture our delivery mechanism. In addition to the PCB and included SMT components, the device uses a Seeeduino Xiao ESP32C3 and two mini peristaltic pumps (Takasago Fluidic Systems, RP-Q) connected to thin silicone tubing (ID = 1 mm; OD = 2 mm) via barbed connectors. Each tube is then connected to the droplet generator.

## Citing

When using or building upon this device in an academic publication, please consider citing as follows:

Alex Mazursky, Jacob Serfaty, and Pedro Lopes. 2024. Stick&Slip: Altering Fingerpad Friction via Liquid Coatings. In Proceedings of the CHI Conference on Human Factors in Computing Systems (CHI ’24), May 11–16, 2024, Honolulu, HI, USA. ACM, New York, NY, USA, 14 pages. https://doi.org/10.1145/3613904.3642299

## Contact

For any questions about this repository, please contact alexmazursky@uchicago.edu
