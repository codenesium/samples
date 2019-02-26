import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BillOfMaterialMapper from '../billOfMaterial/billOfMaterialMapper';
import BillOfMaterialViewModel from '../billOfMaterial/billOfMaterialViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import ReactTable from 'react-table';

interface BillOfMaterialTableComponentProps {
  billOfMaterialsID: number;
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
    this.props.history.push(ClientRoutes.BillOfMaterials + '/edit/' + row.id);
  }

  handleDetailClick(e: any, row: BillOfMaterialViewModel) {
    this.props.history.push(ClientRoutes.BillOfMaterials + '/' + row.id);
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(this.props.apiRoute, {
        headers: {
          'Content-Type': 'application/json',
        },
      })
      .then(
        resp => {
          let response = resp.data as Array<
            Api.BillOfMaterialClientResponseModel
          >;

          console.log(response);

          let mapper = new BillOfMaterialMapper();

          let billOfMaterials: Array<BillOfMaterialViewModel> = [];

          response.forEach(x => {
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
                    Header: 'BillOfMaterialsID',
                    accessor: 'billOfMaterialsID',
                    Cell: props => {
                      return (
                        <span>{String(props.original.billOfMaterialsID)}</span>
                      );
                    },
                  },
                  {
                    Header: 'BOMLevel',
                    accessor: 'bOMLevel',
                    Cell: props => {
                      return <span>{String(props.original.bOMLevel)}</span>;
                    },
                  },
                  {
                    Header: 'ComponentID',
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
                            props.original.componentIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'EndDate',
                    accessor: 'endDate',
                    Cell: props => {
                      return <span>{String(props.original.endDate)}</span>;
                    },
                  },
                  {
                    Header: 'ModifiedDate',
                    accessor: 'modifiedDate',
                    Cell: props => {
                      return <span>{String(props.original.modifiedDate)}</span>;
                    },
                  },
                  {
                    Header: 'PerAssemblyQty',
                    accessor: 'perAssemblyQty',
                    Cell: props => {
                      return (
                        <span>{String(props.original.perAssemblyQty)}</span>
                      );
                    },
                  },
                  {
                    Header: 'ProductAssemblyID',
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
                            props.original.productAssemblyIDNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'StartDate',
                    accessor: 'startDate',
                    Cell: props => {
                      return <span>{String(props.original.startDate)}</span>;
                    },
                  },
                  {
                    Header: 'UnitMeasureCode',
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
                            props.original.unitMeasureCodeNavigation.toDisplay()
                          )}
                        </a>
                      );
                    },
                  },
                  {
                    Header: 'Actions',
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
    <Hash>05e9dd1f4a8a1fbe0693c1733a49c747</Hash>
</Codenesium>*/