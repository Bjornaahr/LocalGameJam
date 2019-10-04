using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour
{

    [SerializeField]
    float oil, rainforest, coal, naturalGas, toxicWasteDumped;
    [SerializeField]
    bool wasteDumping;

    [SerializeField]
    float politicalResistance = 0.001f;
    [SerializeField]
    float lobbyingPower;

    [SerializeField]
    int oilWells, loggingSites, coalMines, dumpingFacilities;

    [SerializeField]
    float co2Zone;

    [SerializeField]
    float co2Modifier = 1;


    void Update()
    {
        if(oil >= 0)
            PumpOil();
        if (rainforest >= 0)
            Deforestation();
        if (coal >= 0)
            MineCoal();
        if (naturalGas >= 0)
            PumpNaturalGas();
        if (wasteDumping)
            DumpToxicWaste();
    }


    void PumpOil()
    {
        oil -= 0.2f * oilWells;
        co2Zone += co2Modifier * oilWells * 0.5f;
    }

    void Deforestation()
    {
        rainforest -= 0.1f * loggingSites;
        co2Modifier += 0.00000000001f * loggingSites;
        politicalResistance += 0.0001f * loggingSites;
    }

    void MineCoal()
    {
        coal -= 0.3f * coalMines;
        co2Zone += co2Modifier * coalMines * 0.8f;
    }

    void PumpNaturalGas()
    {
        naturalGas -= 0.1f * oilWells;
        co2Zone += co2Modifier * oilWells * 0.1f;
    }

    void DumpToxicWaste()
    {
        toxicWasteDumped += dumpingFacilities * 0.03f;
        co2Modifier += 0.000001f * dumpingFacilities;
        politicalResistance += 0.01f * dumpingFacilities;
    }


    void buyCoalMine()
    {
        coalMines++;
    }

    void buyWasteDump()
    {
        dumpingFacilities++;
    }

    void buyLoggingSite()
    {
        loggingSites++;
    }


    void requestWasteDumping()
    {
        if(politicalResistance < lobbyingPower)
        {
            wasteDumping = true;
        }
    }




}
