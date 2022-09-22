import { useEffect, useState } from "react"
import { useAuth0 } from "@auth0/auth0-react";
import WorkItem from "./WorkItem";

const WorkItemList = () => {
    const { getAccessTokenSilently } = useAuth0();
    const [workItems, setWorkItems] = useState([]);

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

        fetchWorkItems();
    }, [getAccessTokenSilently])

    return (
        <>
            <h1>WorkItemList</h1>
            {workItems.map((workItem) => (
                <WorkItem key={workItem.id} workItem={workItem} />
            ))}
        </>
    )
}

export default WorkItemList