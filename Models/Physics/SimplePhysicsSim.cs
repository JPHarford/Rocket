﻿using System;
using System.Diagnostics;
using JetBrains.Annotations;

namespace OpenApogee.Models.Physics {
    public class SimplePhysicsSim {
        private Vector3 _position = new();
        private Vector3 _velocity = new();
        private Vector3 _momentum  = new();

        private double _mass = 1;
        private double _thrust = 15;
        
        public float Simulate() {
            //TODO: Actually do the physics math by hand to find the max height for a given values (Write a test that dose this for you).
            //TODO: Split This calculation into multiple files (I.E. SimpleRocket Class and A Simulation Class).
            //TODO: Implement Rotation and Rotation Forces on the Body (Quaternion).
            //TODO: Add Center of Mass, Thrust, Drag, and Lift to body.
            //TODO: Calculate Drag from given altitude.

            float apogee = 0;
            
            PhysicsRefrenceTime refrenceTime = new(0.001);

            while (_position.Y > -0.1) {

                if (refrenceTime.CurrentTime < 1) {
                    _momentum.Y += (_thrust + _mass * -9.8) * refrenceTime.TimeDelta;
                }
                else {
                    _momentum.Y += _mass * -9.8 * refrenceTime.TimeDelta;
                }
                _velocity = _momentum / _mass;

                _position += _velocity * refrenceTime.TimeDelta;
                

                apogee = apogee < _position.Y ? (float)_position.Y : apogee;
                
                refrenceTime.UpdateTime();
            }

            return apogee;
        }
        

    }
}