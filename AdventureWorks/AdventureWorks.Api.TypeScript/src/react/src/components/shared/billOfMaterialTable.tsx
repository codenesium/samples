import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BillOfMaterialMapper from '../billOfMaterial/billOfMaterialMapper';
import BillOfMaterialViewModel from '../billOfMaterial/billOfMaterialViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface BillOfMaterialTableComponentProps {
  apiRoute: string;
  history: any;
  match: any;
}

interface BillOfMaterialTableComponentState {
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  filteredRecords: Array<BillOfMaterialViewModel>;
}

export class BillOfMaterialTableComponent extends React.Component<
  BillOfMaterialTableComponentProps,
  BillOfMaterialTableComponentState
> {
  state = {
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
    filteredRecords: [],
  };

  handleEditClick(e: any, row: BillOfMaterialViewModel) {
    this.props.history.push(
      ClientRoutes.BillOfMaterials + '/edit/' + row.billOfMaterialsID
    );
  }

  handleDetailClick(e: any, row: BillOfMaterialViewModel) {
    this.props.history.push(
      ClientRoutes.BillOfMaterials + '/' + row.billOfMaterialsID
    );
  }

  componentDidMount() {
    this.loadRecords();
  }

  loadRecords() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Array<Api.BillOfMaterialClientResponseModel>>(this.props.apiRoute, {
        headers: GlobalUtilities.defaultHeaders(),
      })
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new BillOfMaterialMapper();

        let billOfMaterials: Array<BillOfMaterialViewModel> = [];

        response.data.forEach(x => {
          billOfMaterials.push(mapper.mapApiResponseToViewModel(x));
        });

        this.setState({
          ...this.state,
          filteredRecords: billOfMaterials,
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.errorOccurred) {
      return <Alert message={this.state.errorMessage} type="error" />;
    } else if (this.state.loaded) {
      return (
        <div>
          {message}
          <ReactTable
            data={this.state.filteredRecords}
            defaultPageSize={10}
            columns={[
              {
                Header: 'BillOfMaterials',
                columns: [
                  {
                    Header: 'B O M Level',
                    accessor: 'bOMLevel',
                    Cell: props => {
                      return <span>{String(props.original.bOMLevel)}</span>;
                    },
                  },
                  {
                    Header: 'Component I D',
                    accessor: 'componentID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Products +
                                '/' +
                                props.original.componentID
                            );
                          }}
                        >
                          {String(
                            props.original.componentIDNavigation &&
                              props.original.componentIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'End Date',
                    accessor: 'endDate',
                    Cell: props => {
                      return <span>{String(props.original.endDate)}</span>;
                    },
                  },
                  {
                    Header: 'Modified Date',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'Per Assembly Qty',
                    accessor: 'perAssemblyQty',
                    Cell: props => {
                      return (
                        <span>{String(props.original.perAssemblyQty)}</span>
                      );
                    },
                  },
                  {
                    Header: 'Product Assembly I D',
                    accessor: 'productAssemblyID',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.Products +
                                '/' +
                                props.original.productAssemblyID
                            );
                          }}
                        >
                          {String(
                            props.original.productAssemblyIDNavigation &&
                              props.original.productAssemblyIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Start Date',
                    accessor: 'startDate',
                    Cell: props => {
                      return <span>{String(props.original.startDate)}</span>;
                    },
                  },
                  {
                    Header: 'Unit Measure Code',
                    accessor: 'unitMeasureCode',
                    Cell: props => {
                      return (
                        <a
                          href=""
                          onClick={e => {
                            e.preventDefault();
                            this.props.history.push(
                              ClientRoutes.UnitMeasures +
                                '/' +
                                props.original.unitMeasureCode
                            );
                          }}
                        >
                          {String(
                            props.original.unitMeasureCodeNavigation &&
                              props.original.unitMeasureCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
                    minWidth: 150,
                    Cell: row => (
                      <div>
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleDetailClick(
                              e,
                              row.original as BillOfMaterialViewModel
                            );
                          }}
                        >
                          <i className="fas fa-search" />
                        </Button>
                        &nbsp;
                        <Button
                          type="primary"
                          onClick={(e: any) => {
                            this.handleEditClick(
                              e,
                              row.original as BillOfMaterialViewModel
                            );
                          }}
                        >
                          <i className="fas fa-edit" />
                        </Button>
                      </div>
                    ),
                  },
                ],
              },
            ]}
          />
        </div>
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>fdd24a4a1fb6a8ab4c6cf626a328a767</Hash>
</Codenesium>*/