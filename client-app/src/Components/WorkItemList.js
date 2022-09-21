import { useEffect, useState } from "react"
import { useAuth0 } from "@auth0/auth0-react";
import WorkItem from "./WorkItem";
import WorkItemType from "./WorkItemType";

const WorkItemList = () => {
    const { getAccessTokenSilently } = useAuth0();
    const [workItems, setWorkItems] = useState([]);
    const [workItemTypes, setWorkItemTypes] = useState([]);

    useEffect(() => {
        const fetchWorkItems = async () => {
            const token = await getAccessTokenSilently({
                audience: "https://amillner-ado-clone/",
            });

            const res = await fetch(`${process.env.REACT_APP_API_URL}/workitem`,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );

            var body = await res.json();
            setWorkItems(body);
        }

        const fetchWorkItemTypes = async () => {
            const token = await getAccessTokenSilently({
                audience: "https://amillner-ado-clone/",
            });

            const res = await fetch(`${process.env.REACT_APP_API_URL}/workItemType`,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );

            var body = await res.json();
            setWorkItemTypes(body);
        }

        fetchWorkItems();
        fetchWorkItemTypes();
    }, [getAccessTokenSilently])

    return (
        <>
            <h1>WorkItemList</h1>
            {workItems.map((workItem) => (
                <WorkItem key={workItem.id} workItem={workItem} />
            ))}

            <h1>WorkItemTypes</h1>
            {workItemTypes.map((workItemType) => (
                <WorkItemType key={workItemType.id} workItemType={workItemType} />
            ))}
        </>
    )
}

export default WorkItemList