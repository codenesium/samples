import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import LinkMapper from './linkMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import ReactTable from "react-table";
import LinkViewModel from './linkViewModel';
import "react-table/react-table.css";
import { Form, Button, Input, Row, Col, Alert, Spin } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface LinkSearchComponentProps
{
     form:WrappedFormUtils;
	 history:any;
	 match:any;
}

interface LinkSearchComponentState
{
    records:Array<LinkViewModel>;
    filteredRecords:Array<LinkViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class LinkSearchComponent extends React.Component<LinkSearchComponentProps, LinkSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<LinkViewModel>(), filteredRecords:new Array<LinkViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:LinkViewModel) {
         this.props.history.push(ClientRoutes.Links + '/edit/' + row.id);
    }

    handleDetailClick(e:any, row:LinkViewModel) {
         this.props.history.push(ClientRoutes.Links + '/' + row.id);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.Links + '/create');
    }

    handleDeleteClick(e:any, row:Api.LinkClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.Links + '/' + row.id,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            this.setState({...this.state, deleteResponse:'Record deleted', deleteSuccess:true, deleteSubmitted:true});
            this.loadRecords(this.state.searchValue);
        }, error => {
            console.log(error);
            this.setState({...this.state, deleteResponse:'Error deleting record', deleteSuccess:false, deleteSubmitted:true});
        })
    }

   handleSearchChanged(e:React.FormEvent<HTMLInputElement>) {
		this.loadRecords(e.currentTarget.value);
   }
   
   loadRecords(query:string = '') {
	   this.setState({...this.state, searchValue:query});
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.Links + '?limit=100';

	   if(query)
	   {
		   searchEndpoint += '&query=' +  query;
	   }

	   axios.get(searchEndpoint,
	   {
		   headers: {
			   'Content-Type': 'application/json',
		   }
	   })
	   .then(resp => {
		    let response = resp.data as Array<Api.LinkClientResponseModel>;
		    let viewModels : Array<LinkViewModel> = [];
			let mapper = new LinkMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<LinkViewModel>(), filteredRecords:new Array<LinkViewModel>(), loading:false, loaded:true, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <Spin size="large" />;
        } 
		else if(this.state.errorOccurred) {
            return <Alert message={this.state.errorMessage} type="error" />
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if (this.state.deleteSubmitted) {
				if (this.state.deleteSuccess) {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="success" style={{marginBottom:"25px"}} />
				  );
				} else {
				  errorResponse = (
					<Alert message={this.state.deleteResponse} type="error" style={{marginBottom:"25px"}} />
				  );
				}
			}
            
			return (
            <div>
            {errorResponse}
            <Row>
				<Col span={8}></Col>
				<Col span={8}>   
				   <Input 
					placeholder={"Search"} 
					id={"search"} 
					onChange={(e:any) => {
					  this.handleSearchChanged(e)
				   }}/>
				</Col>
				<Col span={8}>  
				  <Button 
				  style={{'float':'right'}}
				  type="primary" 
				  onClick={(e:any) => {
                        this.handleCreateClick(e)
						}}
				  >
				  +
				  </Button>
				</Col>
			</Row>
			<br />
			<br />
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'Links',
                    columns: [
					  {
                      Header: 'AssignedMachineId',
                      accessor: 'assignedMachineId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Machines + '/' + props.original.assignedMachineId); }}>
                          {String(
                            props.original.assignedMachineIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'ChainId',
                      accessor: 'chainId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Chains + '/' + props.original.chainId); }}>
                          {String(
                            props.original.chainIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'DateCompleted',
                      accessor: 'dateCompleted',
                      Cell: (props) => {
                      return <span>{String(props.original.dateCompleted)}</span>;
                      }           
                    },  {
                      Header: 'DateStarted',
                      accessor: 'dateStarted',
                      Cell: (props) => {
                      return <span>{String(props.original.dateStarted)}</span>;
                      }           
                    },  {
                      Header: 'DynamicParameter',
                      accessor: 'dynamicParameter',
                      Cell: (props) => {
                      return <span>{String(props.original.dynamicParameter)}</span>;
                      }           
                    },  {
                      Header: 'ExternalId',
                      accessor: 'externalId',
                      Cell: (props) => {
                      return <span>{String(props.original.externalId)}</span>;
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'LinkStatusId',
                      accessor: 'linkStatusId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.LinkStatuses + '/' + props.original.linkStatusId); }}>
                          {String(
                            props.original.linkStatusIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Name',
                      accessor: 'name',
                      Cell: (props) => {
                      return <span>{String(props.original.name)}</span>;
                      }           
                    },  {
                      Header: 'Order',
                      accessor: 'order',
                      Cell: (props) => {
                      return <span>{String(props.original.order)}</span>;
                      }           
                    },  {
                      Header: 'Response',
                      accessor: 'response',
                      Cell: (props) => {
                      return <span>{String(props.original.response)}</span>;
                      }           
                    },  {
                      Header: 'StaticParameter',
                      accessor: 'staticParameter',
                      Cell: (props) => {
                      return <span>{String(props.original.staticParameter)}</span>;
                      }           
                    },  {
                      Header: 'TimeoutInSecond',
                      accessor: 'timeoutInSecond',
                      Cell: (props) => {
                      return <span>{String(props.original.timeoutInSecond)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as LinkViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleEditClick(
                              e,
                              row.original as LinkViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        &nbsp;
                        <Button
                          type="danger" 
                          onClick={(e:any) => {
                            this.handleDeleteClick(
                              e,
                              row.original as LinkViewModel
                            );
                          }}
                        >
                          <i className="far fa-trash-alt" />
                        </Button>

                        </div>)
                    }],
                    
                  }]} />
                  </div>);
        } 
		else {
		  return null;
		}
    }
}

export const WrappedLinkSearchComponent = Form.create({ name: 'Link Search' })(LinkSearchComponent);

/*<Codenesium>
    <Hash>b1b433be43a7de530dbda18414911c3c</Hash>
</Codenesium>*/