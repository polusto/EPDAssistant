﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
	private GameObject selectionButton;

	private bool isSelectable;
	public bool IsSelectable
	{
		get
		{
			return isSelectable;
		}
		set
		{ 
			if (isSelectable != value) 
			{
				isSelectable = value;

				if (isSelectable) 
				{
					selectionButton = NodeSelectionManager.Instance.GetNodeSelector(this);
					selectionButton.GetComponent<Selecting> ().n = this;
				}
				else 
				{
					NodeSelectionManager.Instance.DisableButton(selectionButton);
					selectionButton = null;
				}
			}
		}
	}

    public void DebugListConnections()
    {
        string msg = "Connections for node " + gameObject.name;

        var conns = GraphManager.Instance.GetConnections(this);
        foreach (var conn in conns)
        {
            string otherName = (conn.m_Node1 == this ? conn.m_Node2 : conn.m_Node1).gameObject.name;
            msg += otherName + ", ";
        }
        Debug.Log(msg);

    }

    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, 1f);
    }
}
