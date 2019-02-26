import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AirTransportMapper from '../airTransport/airTransportMapper';
import AirTransportViewModel from '../airTransport/airTransportViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from "react-table";

interface AirTransportTableComponentProps {
  id:number,
  apiRoute:string;
  history: any;
  match: any;
}

interface AirTransportTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords : Array<AirTransportViewModel>;
}

export class  AirTransportTableComponent extends React.Component<
AirTransportTableComponentProps,
AirTransportTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords:[]
  };

handleEditClick(e:any, row: AirTransportViewModel) {
  this.props.history.push(ClientRoutes.AirTransports + '/edit/' + row.id);
}

 handleDetailClick(e:any, row: AirTransportViewModel) {
   this.props.history.push(ClientRoutes.AirTransports + '/' + row.id);
 }

  componentDidMount() {
	this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Array<Api.AirTransportClientResponseModel>;

          console.log(response);

          let mapper = new AirTransportMapper();
          
          let airTransports:Array<AirTransportViewModel> = [];

          response.forEach(x =>
          {
              airTransports.push(mapper.mapApiResponseToViewModel(x));
          });
          this.setState({
            ...this.state,
            filteredRecords: airTransports,
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            ...this.state,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
	let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
       return <Spin size="large" />;
    }
	else if (this.state.errorOccurred) {
	  return <Alert message={this.state.errorMessage} type='error' />;
	}
	 else if (this.state.loaded) {
      return (
	  <div>
		{message}
         <ReactTable 
                data={this.state.filteredRecords}
				defaultPageSize={10}
                columns={[{
                    Header: 'AirTransports',
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
					    minWidth:150,
                        Cell: row => (<div>
					    <Button
                          type="primary" 
                          onClick={(e:any) => {
                            this.handleDetailClick(
                              e,
                              row.original as AirTransportViewModel
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
                              row.original as AirTransportViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                        </div>)
                    }],
                    
                  }]} />
			</div>
      );
    } else {
      return null;
    }
  }
}

/*<Codenesium>
    <Hash>7670e0a4f5a71ad0a8554fb54f9d6dc7</Hash>
</Codenesium>*/