import React, { Component, ReactElement, ReactHTMLElement } from 'react';
import axios from 'axios';
import { Redirect } from 'react-router-dom';
import * as Api from '../../api/models';
import AirTransportMapper from './airTransportMapper';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import ReactTable from "react-table";
import AirTransportViewModel from './airTransportViewModel';
import "react-table/react-table.css";

interface AirTransportSearchComponentProps
{
    history:any;
}

interface AirTransportSearchComponentState
{
    records:Array<AirTransportViewModel>;
    filteredRecords:Array<AirTransportViewModel>;
    loading:boolean;
    loaded:boolean;
    errorOccurred:boolean;
    errorMessage:string;
    searchValue:string;
    deleteSubmitted:boolean;
    deleteSuccess:boolean;
    deleteResponse:string;
}

export default class AirTransportSearchComponent extends React.Component<AirTransportSearchComponentProps, AirTransportSearchComponentState> {

    state = ({deleteSubmitted:false, deleteSuccess:false, deleteResponse:'', records:new Array<AirTransportViewModel>(), filteredRecords:new Array<AirTransportViewModel>(), searchValue:'', loading:false, loaded:true, errorOccurred:false, errorMessage:''});
    
    componentDidMount () {
        this.loadRecords();
    }

    handleEditClick(e:any, row:Api.AirTransportClientResponseModel) {
         this.props.history.push(ClientRoutes.AirTransports + '/edit/' + row.airlineId);
    }

    handleDetailClick(e:any, row:Api.AirTransportClientResponseModel) {
         this.props.history.push(ClientRoutes.AirTransports + '/' + row.airlineId);
    }

    handleCreateClick(e:any) {
        this.props.history.push(ClientRoutes.AirTransports + '/create');
    }

    handleDeleteClick(e:any, row:Api.AirTransportClientResponseModel) {
        axios.delete(Constants.ApiEndpoint + ApiRoutes.AirTransports + '/' + row.airlineId,
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
	   let searchEndpoint = Constants.ApiEndpoint + ApiRoutes.AirTransports + '?limit=100';

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
		    let response = resp.data as Array<Api.AirTransportClientResponseModel>;
		    let viewModels : Array<AirTransportViewModel> = [];
			let mapper = new AirTransportMapper();

			response.forEach(x =>
			{
				viewModels.push(mapper.mapApiResponseToViewModel(x));
			})

            this.setState({records:viewModels, filteredRecords:viewModels, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

	   }, error => {
		   console.log(error);
		   this.setState({records:new Array<AirTransportViewModel>(),filteredRecords:new Array<AirTransportViewModel>(), loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
	   })
    }

    filterGrid() {

    }
    
    render () {
        if(this.state.loading) {
            return <LoadingForm />;
        } 
		else if(this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if(this.state.loaded) {

            let errorResponse:JSX.Element = <span></span>;

            if(this.state.deleteSubmitted){
                if(this.state.deleteSuccess){
                    errorResponse =<div className="alert alert-success">{this.state.deleteResponse}</div>   
                }
                else {
                    errorResponse = <div className="alert alert-danger">{this.state.deleteResponse}</div>   
                }
            }
            return (
            <div>
                { 
                    errorResponse
                }
            <form>
                <div className="form-group row">
                    <div className="col-sm-4">
                    </div>
                    <div className="col-sm-4">
                        <input name="search" className="form-control" placeholder={"Search"} value={this.state.searchValue} onChange={e => this.handleSearchChanged(e)}/>
                    </div>
                    <div className="col-sm-4">
                        <button className="btn btn-primary btn-sm align-middle float-right vertically-center search-create-button" onClick={e => this.handleCreateClick(e)}><i className="fas fa-plus"></i></button>
                    </div>
                </div>
            </form>
            <ReactTable 
                data={this.state.filteredRecords}
                columns={[{
                    Header: 'AirTransport',
                    columns: [
					  {
                      Header: 'AirlineId',
                      accessor: 'airlineId',
                      Cell: (props) => {
                      return <span>{String(props.original.airlineId)}</span>;
                      }           
                    },  {
                      Header: 'FlightNumber',
                      accessor: 'flightNumber',
                      Cell: (props) => {
                      return <span>{String(props.original.flightNumber)}</span>;
                      }           
                    },  {
                      Header: 'HandlerId',
                      accessor: 'handlerId',
                      Cell: (props) => {
                        return <a href='' onClick={(e) => { e.preventDefault(); this.props.history.push(ClientRoutes.Handlers + '/' + props.original.handlerId); }}>
                          {String(
                            props.original.handlerIdNavigation.toDisplay()
                          )}
                        </a>
                      }           
                    },  {
                      Header: 'Id',
                      accessor: 'id',
                      Cell: (props) => {
                      return <span>{String(props.original.id)}</span>;
                      }           
                    },  {
                      Header: 'LandDate',
                      accessor: 'landDate',
                      Cell: (props) => {
                      return <span>{String(props.original.landDate)}</span>;
                      }           
                    },  {
                      Header: 'PipelineStepId',
                      accessor: 'pipelineStepId',
                      Cell: (props) => {
                      return <span>{String(props.original.pipelineStepId)}</span>;
                      }           
                    },  {
                      Header: 'TakeoffDate',
                      accessor: 'takeoffDate',
                      Cell: (props) => {
                      return <span>{String(props.original.takeoffDate)}</span>;
                      }           
                    },
                    {
                        Header: 'Actions',
                        Cell: row => (<div><button className="btn btn-sm" onClick={e => {this.handleDetailClick(e, row.original as Api.AirTransportClientResponseModel)}} ><i className="fas fa-search"></i></button>
                        &nbsp;<button className="btn btn-primary btn-sm" onClick={e => {this.handleEditClick(e, row.original as Api.AirTransportClientResponseModel)}} ><i className="fas fa-edit"></i></button>
                        &nbsp;<button className="btn btn-danger btn-sm" onClick={e => {this.handleDeleteClick(e, row.original as Api.AirTransportClientResponseModel)}} ><i className="far fa-trash-alt"></i></button>
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

/*<Codenesium>
    <Hash>79c924076bd1f5a6a3dfb3a34bab76e5</Hash>
</Codenesium>*/