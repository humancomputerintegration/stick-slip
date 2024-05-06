<p align="center">

![](/Images/figure_01-no-labels.png?raw=true)

</p>

# Stick&Slip

This is a repository for the prototype ThermalGrasp devices created by Alex Mazursky, Jacob Serfaty, and Pedro Lopes at the University of Chicago's [Human Computer Integration Lab](https://lab.plopes.org/). Our wearable thermal interfaces made with the ThermalGrasp approach enable users to grab and walk on real objects with minimal obstruction. For specific study details, please refer to our paper.

## Repository Structure

* `Arduino` contains code for the microcontroller (Arduino Mega).
* `3D-prints` contains models for the form-fitting shells for the hands and feet (.stl files). These can be printed in regular PLA using an FDM 3D printer. Additionally includes Fusion360 assemblies (.f3d files) of the entire device (shells, peltiers, fans, copper, etc.).

## Hardware

<p align="center">

![](/Images/device-2.png?raw=true)

</p>

Here are the specific hardware components used in each device instantiation and our hardware used in Study 2's backpack.

- Peltiers (foot: TEC12706, hand: CP60231H)
- Copper heat pipes (foot: 70W 11.2 x 3.5 x 100mm, hand: 60W 8.3 x 2.5 x 70mm)
- Copper sheet metal (0.2mm thick)
- Neoprene foam (3.2mm thick, easily compressible)
- Heatsinks (foot: 40 x 40 x 12mm, hand: 20 x 20 x 10mm)
- Fans (foot: 24V, 40 x 40mm, hand: 12V, 20 x 20mm)
- Temperature sensors (100kΩ NTC 3950 thermistors) 
- Motor drivers (VNH3SP30)
- Microcontroller (ATmega2560/Arduino Mega)
- MOSFET (RFP30N06LE, triggers fans)

## Citing

When using or building upon this device in an academic publication, please consider citing as follows:

A. Mazursky, J. Brooks, B. Desta and P. Lopes, "ThermalGrasp: Enabling Thermal Feedback even while Grasping and Walking," in 2024 IEEE Conference Virtual Reality and 3D User Interfaces (VR), Orlando, FL, USA, 2024 pp. 342-353.
doi: 10.1109/VR58804.2024.00056

## Contact

For any questions about this repository, please contact alexmazursky@uchicago.edu
