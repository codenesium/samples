import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BillOfMaterialMapper from './billOfMaterialMapper';
import BillOfMaterialViewModel from './billOfMaterialViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';

interface BillOfMaterialDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface BillOfMaterialDetailComponentState {
  model?: BillOfMaterialViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class BillOfMaterialDetailComponent extends React.Component<
  BillOfMaterialDetailComponentProps,
  BillOfMaterialDetailComponentState
> {
  state = {
    model: new BillOfMaterialViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.BillOfMaterials +
        '/edit/' +
        this.state.model!.billOfMaterialsID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.BillOfMaterialClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.BillOfMaterials +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new BillOfMaterialMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
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
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>B O M Level</h3>
              <p>{String(this.state.model!.bOMLevel)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Component I D</h3>
              <p>
                {String(
                  this.state.model!.componentIDNavigation &&
                    this.state.model!.componentIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>End Date</h3>
              <p>{String(this.state.model!.endDate)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Per Assembly Qty</h3>
              <p>{String(this.state.model!.perAssemblyQty)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Product Assembly I D</h3>
              <p>
                {String(
                  this.state.model!.productAssemblyIDNavigation &&
                    this.state.model!.productAssemblyIDNavigation!.toDisplay()
                )}
              </p>
            </div>
            <div>
              <h3>Start Date</h3>
              <p>{String(this.state.model!.startDate)}</p>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>Unit Measure Code</h3>
              <p>
                {String(
                  this.state.model!.unitMeasureCodeNavigation &&
                    this.state.model!.unitMeasureCodeNavigation!.toDisplay()
                )}
              </p>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedBillOfMaterialDetailComponent = Form.create({
  name: 'BillOfMaterial Detail',
})(BillOfMaterialDetailComponent);


/*<Codenesium>
    <Hash>3d2fd8ab3f4814bf183f71e39ce71b2b</Hash>
</Codenesium>*/